using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using EasySII;
using EasySII.Business;
using EasySII.Net;
using EasySII.Xml;
using EasySII.Xml.Sii;
using EasySII.Xml.Silr;
using EasySII.Xml.Soap;
using System.Collections.Generic;

namespace Sample
{
    class EmitidasEnvel
    {

        public void GenerarXMLEmitidasEnvel(string _NombreFichero)
        {

            EmitidasEnvel funcion = new EmitidasEnvel();
            string _NomFicheroWrk = _NombreFichero;

            try
            {
                Envelope _EnvelWrk = new Envelope();
                SuministroLRFacturasEmitidas _SumLRFactEmit = new SuministroLRFacturasEmitidas();
                RegistroLRFacturasEmitidas _RegLRFactEmit = new RegistroLRFacturasEmitidas();

                Cabecera _Cabecera = new Cabecera();

                bool _NuevaFact = false;

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
                                    _SumLRFactEmit.Cabecera = _Cabecera;
                                    break;
                                case "FACT":
                                    if (_NuevaFact) // Si se trata de una nueva factura, añadiremos la 'antigua' al fichero
                                    {
                                        _SumLRFactEmit.RegistroLRFacturasEmitidas.Add(_RegLRFactEmit);
                                        _NuevaFact = false;
                                    }
                                    _RegLRFactEmit = new RegistroLRFacturasEmitidas();
                                    _RegLRFactEmit = funcion.TratarFactEmitida(_CamposReg);
                                    break;
                                case "RECT":
                                    _RegLRFactEmit = funcion.AgregarFactRectifica(_CamposReg, _RegLRFactEmit);
                                    break;

                                case "FISC":
                                    _NuevaFact = true;
                                    _RegLRFactEmit = funcion.AgregarDesgloseIVA(_CamposReg, _RegLRFactEmit);
                                    break;
                                case "FINI":
                                    // Incluimos la última factura que hemos tratado.
                                    _SumLRFactEmit.RegistroLRFacturasEmitidas.Add(_RegLRFactEmit);

                                    // Incluimos todas las facturas tratadas en el Envelope.
                                    _EnvelWrk.Body.SuministroLRFacturasEmitidas = _SumLRFactEmit;

                                    //Obtenemos la fecha actual sin la hora y procedemos a crear la ruta/nombre del fichero resultante
                                    DateTime _FechaActual = DateTime.Today;
                                    string nombrefichero = "SII_Emitidas_" + _Cabecera.Titular.NIF + "_" + _FechaActual.ToString("yyyyMMdd") + ".XML";
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
        private RegistroLRFacturasEmitidas TratarFactEmitida(string[] _CamposReg)
        {
            RegistroLRFacturasEmitidas _RegLRFactEmitWRK = new RegistroLRFacturasEmitidas();

            // Informamos el periodo impositivo.
            PeriodoImpositivo _PeriodoWrk = new PeriodoImpositivo();
            _PeriodoWrk.Ejercicio = _CamposReg[1];
            _PeriodoWrk.Periodo = _CamposReg[2];
            _RegLRFactEmitWRK.PeriodoImpositivo = _PeriodoWrk;

            // Informamos el IDFactura.
            IDFactura _IDFactWrk = new IDFactura();
            _IDFactWrk.IDEmisorFactura.NIF = _CamposReg[3];
            _IDFactWrk.NumSerieFacturaEmisor = _CamposReg[4].Trim();
            _IDFactWrk.FechaExpedicionFacturaEmisor = _CamposReg[5];

            // En caso de que se trate de una factura de Asiento Resumen, hay que informar la última factura
            // que se incluye en este envío.
            if (!string.IsNullOrWhiteSpace(_CamposReg[14]))
            {
                _IDFactWrk.NumSerieFacturaEmisorResumenFin = _CamposReg[14];
            }
            _RegLRFactEmitWRK.IDFactura = _IDFactWrk;

            // Procedemos a tratar la factura actual.
            FacturaExpedida _FacturaActual = new FacturaExpedida();
            _FacturaActual.TipoFactura = _CamposReg[6];
            _FacturaActual.ClaveRegimenEspecialOTrascendencia = _CamposReg[7];

            _FacturaActual.ImporteTotal = ((_CamposReg[8]).Trim()).Replace(',', '.'); ;

            if (string.IsNullOrWhiteSpace(_CamposReg[9]))
            {
                _CamposReg[9] = "Hay que informar el concepto de la factura";
            }
            _FacturaActual.DescripcionOperacion = _CamposReg[9].Trim();

            // Informamos la contraparte, que cambiará dependiendo de si se trata de un cliente nacional o extranjero
            Contraparte _ClienteWrk = new Contraparte();
            _ClienteWrk.NombreRazon = _CamposReg[10].Trim();
            if (string.IsNullOrWhiteSpace(_CamposReg[12]))
            {
                _ClienteWrk.NIF = _CamposReg[11];
            }
            else
            {
                IDOtro _ClienteExtWrk = new IDOtro();
                _ClienteExtWrk.CodigoPais = _CamposReg[12];
                _ClienteExtWrk.IDType = _CamposReg[13];
                _ClienteExtWrk.ID = _CamposReg[11];
                _ClienteWrk.IDOtro = _ClienteExtWrk;
            }
            _FacturaActual.Contraparte = _ClienteWrk;

            // Indicamos la fecha de operación.
            _FacturaActual.FechaOperacion = _CamposReg[15];

            // Procedemos a informar los campos en el caso de que se trate del envio de una factura rectificativa.
            if (!string.IsNullOrWhiteSpace(_CamposReg[16]))
            {
                _FacturaActual.TipoRectificativa = _CamposReg[16];

                ImporteRectificacion _ImpRectifWrk = new ImporteRectificacion();
                _ImpRectifWrk.BaseRectificada = ((_CamposReg[17]).Trim()).Replace(',', '.');
                _ImpRectifWrk.CuotaRectificada = ((_CamposReg[18]).Trim()).Replace(',', '.');
                _FacturaActual.ImporteRectificacion = _ImpRectifWrk;
            }

            _RegLRFactEmitWRK.FacturaExpedida = _FacturaActual;

            return _RegLRFactEmitWRK;
        }

        /// <summary>
        /// Rutina para añadir los desgloses de IVA correspondientes por cada factura.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>

        private RegistroLRFacturasEmitidas AgregarDesgloseIVA(string[] _CamposReg, RegistroLRFacturasEmitidas _FacturaActual)
        {

            RegistroLRFacturasEmitidas _FactActualWrk = _FacturaActual;
            TipoDesglose _TipoDesgloseTmp = new TipoDesglose();
            DesgloseFactura _DesgloseFactTmp = new DesgloseFactura();
            Sujeta _SujetaTmp = new Sujeta();

            // Procedemos a tratar la factura actual.
            // En este caso añadiremos las líneas de fiscalidad que hayamos leido a la factura que estemos tratando en ese momento
            string _RegImpos = _CamposReg[1];
            if (_RegImpos == "E")
            {
                Exenta _ExentaWrk = new Exenta();
                _ExentaWrk.BaseImponible = ((_CamposReg[4]).Trim()).Replace(',', '.'); ;
                // La CausaExencion es opcional, de manera que no la informamos.
                _SujetaTmp.Exenta = _ExentaWrk;
                _DesgloseFactTmp.Sujeta = _SujetaTmp;
                _TipoDesgloseTmp.DesgloseFactura = _DesgloseFactTmp;
            }
            else
            {
                NoExenta _NoExentaWrk = new NoExenta();
                _NoExentaWrk.TipoNoExenta = _CamposReg[2];
                DesgloseIVA _DesgloseIVAWrk = new DesgloseIVA();

                DetalleIVA _DetalleIVAWrk = new DetalleIVA();
                _DetalleIVAWrk.TipoImpositivo = ((_CamposReg[3]).Trim()).Replace(',', '.'); ;
                _DetalleIVAWrk.BaseImponible = ((_CamposReg[4]).Trim()).Replace(',', '.'); ;
                _DetalleIVAWrk.CuotaRepercutida = ((_CamposReg[5]).Trim()).Replace(',', '.'); ;

                _DesgloseIVAWrk.DetalleIVA.Add(_DetalleIVAWrk);
                _NoExentaWrk.DesgloseIVA = _DesgloseIVAWrk;

                _SujetaTmp.NoExenta = _NoExentaWrk;
                _DesgloseFactTmp.Sujeta = _SujetaTmp;

                _TipoDesgloseTmp.DesgloseFactura = _DesgloseFactTmp;
            }

            _FactActualWrk.FacturaExpedida.TipoDesglose = _TipoDesgloseTmp;
            return _FactActualWrk;
        }

        /// <summary>
        /// Rutina para añadir las facturas rectificadas, en el caso de que estas lleguen informadas.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>

        private RegistroLRFacturasEmitidas AgregarFactRectifica(string[] _CamposReg, RegistroLRFacturasEmitidas _FacturaActual)
        {

            IDFactura factRectifica = new IDFactura();
            factRectifica.NumSerieFacturaEmisor = (_CamposReg[1]).Trim();
            factRectifica.FechaExpedicionFacturaEmisor = _CamposReg[2];

            _FacturaActual.FacturaExpedida.FacturasRectificadas.Add(factRectifica);

            return _FacturaActual;
        }

    }
}
