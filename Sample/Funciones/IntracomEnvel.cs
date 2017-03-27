﻿using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using EasySII.Xml;
using EasySII.Xml.Sii;
using EasySII.Xml.Silr;
using EasySII.Xml.Soap;

namespace Sample
{
    class IntracomEnvel
    {

        public void GenerarXMLIntracomEnvel(string _NombreFichero)
        {

            IntracomEnvel funcion = new IntracomEnvel();
            string _NomFicheroWrk = _NombreFichero;

            try
            {
                Envelope _EnvelWrk = new Envelope();
                SuministroLRDetOperacionIntracomunitaria _SumLROperIntracom = new SuministroLRDetOperacionIntracomunitaria();
                RegistroLRDetOperacionIntracomunitaria _RegLROperIntracom = new RegistroLRDetOperacionIntracomunitaria();

                Cabecera _Cabecera = new Cabecera();

                using (StreamReader _Lector = new StreamReader(_NomFicheroWrk))
                {
                    while (_Lector.Peek() > -1)
                    {
                        string _RegFichero = _Lector.ReadLine();
                        if (!String.IsNullOrEmpty(_RegFichero))
                        {
                            // Con creamos un Array con los distintos campos que contiene el registro separados por ";"
                            string[] _CamposReg = _RegFichero.Split(';');
                            string _TipoReg = _CamposReg[0];

                            switch (_TipoReg)
                            {
                                case "CABE":
                                    _Cabecera = funcion.TratarRegCabecera(_CamposReg);
                                    _SumLROperIntracom.Cabecera = _Cabecera;
                                    break;
                                case "FACT":
                                    _RegLROperIntracom = new RegistroLRDetOperacionIntracomunitaria();
                                    _RegLROperIntracom = funcion.TratarOperIntracom(_CamposReg);
                                    _SumLROperIntracom.RegistroLRDetOperacionIntracomunitaria.Add(_RegLROperIntracom);
                                    break;
                                case "FINI":
                                    // Incluimos todas las facturas tratadas en el Envelope.
                                    _EnvelWrk.Body.SuministroLRDetOperacionIntracomunitaria = _SumLROperIntracom;

                                    //Obtenemos la fecha actual sin la hora y procedemos a crear la ruta/nombre del fichero resultante
                                    DateTime _FechaActual = DateTime.Today;
                                    string nombrefichero = "SII_Intracom_" + _Cabecera.Titular.NIF + "_" + _FechaActual.ToString("yyyyMMdd") + ".XML";
                                    string XmlResult = "C:/Temp/" + nombrefichero;

                                    // Con la siguiente instruccion se genera el XML en la direccion anteriormente indicada.
                                    XmlDocument tmpXML = SIIParser.GetXml(_EnvelWrk, XmlResult);

                                    string _msg = "Fichero XML generado: " + XmlResult;
                                    MessageBox.Show(_msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                default:
                                    string _msgAviso = "Tipo Registro incorrecto: " + _TipoReg;
                                    MessageBox.Show(_msgAviso, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string _msgError = "Error: " + ex.Message;
                MessageBox.Show(_msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Cabecera TratarRegCabecera(string[] _CamposReg)
        {
            Cabecera _CabeceraWrk = new Cabecera();
            //_CabeceraWrk.IDVersionSii = "0.5";

            // Procedemos a informar el titular del libro.
            _CabeceraWrk.Titular.NombreRazon = (_CamposReg[1]).Trim();
            _CabeceraWrk.Titular.NIF = _CamposReg[2];

            _CabeceraWrk.TipoComunicacion = _CamposReg[3];

            return _CabeceraWrk;
        }

        // Función para tratar el registro de factura que se acaba de leer.
        private RegistroLRDetOperacionIntracomunitaria TratarOperIntracom(string[] _CamposReg)
        {
            RegistroLRDetOperacionIntracomunitaria _RegLRFactIntraWrk = new RegistroLRDetOperacionIntracomunitaria();

            // Informamos el periodo impositivo.
            PeriodoImpositivo _PeriodoWrk = new PeriodoImpositivo();
            _PeriodoWrk.Ejercicio = _CamposReg[1];
            _PeriodoWrk.Periodo = _CamposReg[2];
            _RegLRFactIntraWrk.PeriodoImpositivo = _PeriodoWrk;

            //
            // Informamos el IDFactura.
            // Por las pruebas que hemos podido realizar, parece ser que el Emisor de la factura tiene que ser el titular de la misma.
            //
            IDFactura _IDFactWrk = new IDFactura();
            _IDFactWrk.IDEmisorFactura.NombreRazon = _CamposReg[10].Trim();
            _IDFactWrk.IDEmisorFactura.NIF = _CamposReg[11];

            _IDFactWrk.NumSerieFacturaEmisor = _CamposReg[8].Trim();
            _IDFactWrk.FechaExpedicionFacturaEmisor = _CamposReg[9];
            _RegLRFactIntraWrk.IDFactura = _IDFactWrk;

            //
            // Informamos la contraparte, que, según la documentación y las pruebas realizadas, en nuestro caso tendremos que informar 
            // los datos del Proveedor/Acreedor.
            //
            Contraparte _ContraparteWrk = new Contraparte();
            _ContraparteWrk.NombreRazon = _CamposReg[3].Trim();

            if (string.IsNullOrWhiteSpace(_CamposReg[5]))
            {
                _ContraparteWrk.NIF = _CamposReg[4];
            }
            else
            {
                IDOtro _EmisorExt = new IDOtro();
                _EmisorExt.CodigoPais = _CamposReg[5];
                _EmisorExt.IDType = _CamposReg[6];
                _EmisorExt.ID = _CamposReg[7];
                _ContraparteWrk.IDOtro = _EmisorExt;
            }

            _RegLRFactIntraWrk.Contraparte = _ContraparteWrk;


            // Informamos los datos correspondientes a la operación intracomunitaria.
            OperacionIntracomunitaria _OperIntraWrk = new OperacionIntracomunitaria();
            _OperIntraWrk.TipoOperacion = _CamposReg[12];
            _OperIntraWrk.ClaveDeclarado = _CamposReg[13];
            _OperIntraWrk.EstadoMiembro = _CamposReg[14];
            _OperIntraWrk.DescripcionBienes = _CamposReg[15];
            _OperIntraWrk.DireccionOperador = _CamposReg[16];

            _RegLRFactIntraWrk.OperacionIntracomunitaria = _OperIntraWrk;

            return _RegLRFactIntraWrk;
        }
    }
}
