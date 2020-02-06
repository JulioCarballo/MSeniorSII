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

namespace MSeniorSII
{
    class RecibidasEnvel
    {

        public void GenerarXMLRecibidasEnvel(string _NombreFichero)
        {

            RecibidasEnvel funcion = new RecibidasEnvel();
            string _NomFicheroWrk = _NombreFichero;

            try
            {
                Envelope _EnvelWrk = new Envelope();
                SuministroLRFacturasRecibidas _SumLRFactReci = new SuministroLRFacturasRecibidas();
                RegistroLRFacturasRecibidas _RegLRFactReci = new RegistroLRFacturasRecibidas();

                Cabecera _Cabecera = new Cabecera();

                bool _NuevaFact = false;
                int lineasFisc = 0;
                bool _NuevoDetalle = true; 

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
                                    _SumLRFactReci.Cabecera = _Cabecera;
                                    break;
                                case "FACT":
                                    if (_NuevaFact) // Si se trata de una nueva factura, añadiremos la 'antigua' al fichero
                                    {
                                        _SumLRFactReci.RegistroLRFacturasRecibidas.Add(_RegLRFactReci);
                                        _NuevaFact = false;
                                    }
                                    _RegLRFactReci = new RegistroLRFacturasRecibidas();
                                    _RegLRFactReci = funcion.TratarFactRecibida(_CamposReg);
                                    lineasFisc = 0;
                                    _NuevoDetalle = true;
                                    break;
                                case "RECT":
                                    _RegLRFactReci = funcion.AgregarFactRectifica(_CamposReg, _RegLRFactReci);
                                    break;

                                case "FISC":
                                    _NuevaFact = true;
                                    lineasFisc++;
                                    if (lineasFisc > 1)
                                        _NuevoDetalle = false;
                                    _RegLRFactReci = funcion.AgregarDesgloseIVA(_CamposReg, _RegLRFactReci, _NuevoDetalle);
                                    break;
                                case "FINI":
                                    // Tenemos que incluir la última factura que hemos tratado.
                                    _SumLRFactReci.RegistroLRFacturasRecibidas.Add(_RegLRFactReci);

                                    // Incluimos todas las facturas tratadas en el Envelope.
                                    _EnvelWrk.Body.SuministroLRFacturasRecibidas = _SumLRFactReci;

                                    //Obtenemos la fecha actual sin la hora y procedemos a crear la ruta/nombre del fichero resultante
                                    DateTime _FechaActual = DateTime.Today;
                                    string nombrefichero = "SII_Recibidas_" + _Cabecera.Titular.NIF + "_" + _FechaActual.ToString("yyyyMMdd") + ".XML";
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

        /// <summary>
        /// Función para tratar el registro de factura que se acaba de leer. 
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <returns></returns>
        private RegistroLRFacturasRecibidas TratarFactRecibida(string[] _CamposReg)
        {
            RegistroLRFacturasRecibidas _RegLRFactReciWRK = new RegistroLRFacturasRecibidas();

            // Informamos el periodo impositivo.
            PeriodoImpositivo _PeriodoWrk = new PeriodoImpositivo
            {
                Ejercicio = _CamposReg[1],
                Periodo = _CamposReg[2]
            };
            _RegLRFactReciWRK.PeriodoImpositivo = _PeriodoWrk;

            // Informamos el IDFactura.
            IDFactura _IDFactWrk = new IDFactura();
            IDEmisorFactura _IDEmisorFact = new IDEmisorFactura();
            Contraparte _ReceptorWrk = new Contraparte();

            if (string.IsNullOrWhiteSpace(_CamposReg[4]))
            {
                _IDEmisorFact.NIF = _CamposReg[3];
                _ReceptorWrk.NIF = _IDEmisorFact.NIF;
            }
            else
            {
                IDOtro _ProveedorExtWrk = new IDOtro
                {
                    CodigoPais = _CamposReg[4],
                    IDType = _CamposReg[5],
                    ID = _CamposReg[3]
                };
                _IDEmisorFact.IDOtro = _ProveedorExtWrk;

                _ReceptorWrk.IDOtro = _IDEmisorFact.IDOtro;
            }
            _IDFactWrk.IDEmisorFactura = _IDEmisorFact;

            _IDFactWrk.NumSerieFacturaEmisor = _CamposReg[6].Trim();
            _IDFactWrk.FechaExpedicionFacturaEmisor = _CamposReg[7];

            _RegLRFactReciWRK.IDFactura = _IDFactWrk;

            // Procedemos a tratar la factura actual.
            FacturaRecibida _FacturaActual = new FacturaRecibida
            {

                //Aquí indicamos si se trata de una factura 'normal' o es 'rectificativa'.
                TipoFactura = _CamposReg[8],
                ClaveRegimenEspecialOTrascendencia = _CamposReg[9],
                ImporteTotal = ((_CamposReg[10]).Trim()).Replace(',', '.'),
                FechaOperacion = _CamposReg[17]
            };

            if (string.IsNullOrWhiteSpace(_CamposReg[11]))
            {
                _CamposReg[11] = "Hay que informar el concepto de la factura";
            }
            _FacturaActual.DescripcionOperacion = _CamposReg[11].Trim();

            // Informamos la contraparte, que según pruebas con el SOAP, este tiene que ser igual que el IDEmisorFactura
            _ReceptorWrk.NombreRazon = _CamposReg[12].Trim();
            _FacturaActual.Contraparte = _ReceptorWrk;

            _FacturaActual.FechaRegContable = _CamposReg[13];

            // Procedemos a informar los campos en el caso de que se trate del envio de una factura rectificativa.
            if (!string.IsNullOrWhiteSpace(_CamposReg[14]))
            {
                _FacturaActual.TipoRectificativa = _CamposReg[14];

                ImporteRectificacion _ImpRectifWrk = new ImporteRectificacion
                {
                    BaseRectificada = ((_CamposReg[15]).Trim()).Replace(',', '.'),
                    CuotaRectificada = ((_CamposReg[16]).Trim()).Replace(',', '.')
                };
                _FacturaActual.ImporteRectificacion = _ImpRectifWrk;
            }

            // Procedemos a informar la cuota deducible en el caso de que corresponda.
            // Si no viene informada la cuota deducible, pondremos '-1' con el fin de que al volver a generarse el lote
            // la ponga a cero, y si no la calcule.
            if (string.IsNullOrWhiteSpace(_CamposReg[18]))
            {
                _FacturaActual.CuotaDeducible = "-1";
            }
            else
            {
                _FacturaActual.CuotaDeducible = ((_CamposReg[18]).Trim()).Replace(',', '.');
            }

            _RegLRFactReciWRK.FacturaRecibida = _FacturaActual;


            return _RegLRFactReciWRK;
        }

        /// <summary>
        /// Función para agregar los desgloses de IVA que vengan en el fichero.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>
        private RegistroLRFacturasRecibidas AgregarDesgloseIVA(string[] _CamposReg, RegistroLRFacturasRecibidas _FacturaActual, bool _NuevoDetalle)
        {
            RegistroLRFacturasRecibidas _FactActualWrk = _FacturaActual;

            if (_NuevoDetalle)
            {
                _FactActualWrk.FacturaRecibida.DesgloseFactura = new DesgloseFacturaR
                {
                    InversionSujetoPasivo = new DesgloseIVA(),
                    DesgloseIVA = new DesgloseIVA()
                };
            }

            DetalleIVA _DetalleIVAWrk = new DetalleIVA
            {
                TipoImpositivo = ((_CamposReg[3]).Trim()).Replace(',', '.')
            };
            ;
            _DetalleIVAWrk.BaseImponible = ((_CamposReg[4]).Trim()).Replace(',', '.'); ;
            _DetalleIVAWrk.CuotaSoportada = ((_CamposReg[5]).Trim()).Replace(',', '.'); ;

            string esInvSujetoPas = _CamposReg[2];
            switch (esInvSujetoPas)
            {
                case "S":
                    _FactActualWrk.FacturaRecibida.DesgloseFactura.InversionSujetoPasivo.DetalleIVA.Add(_DetalleIVAWrk);
                    break;
                case "N":
                    _FactActualWrk.FacturaRecibida.DesgloseFactura.DesgloseIVA.DetalleIVA.Add(_DetalleIVAWrk);
                    break;
            }


            return _FactActualWrk;
        }

        /// <summary>
        /// Rutina para añadir las facturas rectificadas, en el caso de que estas lleguen informadas.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>

        private RegistroLRFacturasRecibidas AgregarFactRectifica(string[] _CamposReg, RegistroLRFacturasRecibidas _FacturaActual)
        {

            IDFactura factRectifica = new IDFactura
            {
                NumSerieFacturaEmisor = (_CamposReg[1]).Trim(),
                FechaExpedicionFacturaEmisor = _CamposReg[2]
            };

            _FacturaActual.FacturaRecibida.FacturasRectificadas.Add(factRectifica);

            return _FacturaActual;
        }

    }
}
