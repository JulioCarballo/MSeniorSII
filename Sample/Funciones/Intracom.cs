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

namespace Sample
{
    class Intracom
    {

        public void GenerarXMLIntracom(string _NombreFichero)
        {

            Intracom funcion = new Intracom();
            string _NomFicheroWrk = _NombreFichero;
            try
            {
                IOInvoicesBatch _LoteOperIntracom = new IOInvoicesBatch();
                IOInvoice _OperIntracomAct = new IOInvoice();
                Party _Titular = new Party();

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
                                    _Titular = funcion.TratarRegCabecera(_CamposReg);
                                    _LoteOperIntracom.Titular = _Titular;
                                    string _TipoComunicacion = _CamposReg[3];
                                    switch (_TipoComunicacion)
                                    {
                                        case "A0":
                                            _LoteOperIntracom.CommunicationType = CommunicationType.A0;
                                            break;
                                        case "A1":
                                            _LoteOperIntracom.CommunicationType = CommunicationType.A1;
                                            break;
                                        case "A4":
                                            _LoteOperIntracom.CommunicationType = CommunicationType.A4;
                                            break;
                                    }
                                    break;
                                case "FACT":
                                    _OperIntracomAct = new IOInvoice();
                                    _OperIntracomAct = funcion.TratarOperIntracom(_CamposReg, _Titular);
                                    _LoteOperIntracom.IOInvoices.Add(_OperIntracomAct);
                                    break;
                                case "FINI":
                                    // Procedemos a generar el XML final.
                                    DateTime _FechaActual = DateTime.Today; //Obtenemos la fecha actual sin la hora
                                    string nombrefichero = "SII_Intracom_" + _Titular.TaxIdentificationNumber + "_" + _FechaActual.ToString("yyyyMMdd") + ".XML";
                                    string XmlResult = "C:/Temp/" + nombrefichero;
                                    _LoteOperIntracom.GetXml(XmlResult);

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


        private Party TratarRegCabecera(string[] _CamposReg)
        {
            Party _TitularWrk = new Party();

            _TitularWrk.PartyName = (_CamposReg[1]).Trim();
            _TitularWrk.TaxIdentificationNumber = _CamposReg[2];

            return _TitularWrk;
        }

        // Función para tratar el registro de factura que se acaba de leer.
        private IOInvoice TratarOperIntracom(string[] _CamposReg, Party _Titular)
        {
            IOInvoice _FacturaActual = new IOInvoice();
            Party _Emisor, _Cliente = new Party();

            // Por las pruebas que hemos podido realizar, parece ser que el Emisor de la factura tiene que ser el titular de la misma.
            _Emisor = _Titular;
            _FacturaActual.BuyerParty = _Emisor;

            // Procedemos a tratar la factura actual.
            //El periodo impositivo no lo informamos, ya que se informará automáticamente a partir
            // de la fecha de la factura, según las pruebas que hemos realizado.
            _FacturaActual.InvoiceNumber = (_CamposReg[7]).Trim();
            _FacturaActual.IssueDate = Convert.ToDateTime(_CamposReg[8]);

            // Informamos el Proveedor/Acreedor en nuestro caso.
            _Cliente.PartyName = (_CamposReg[3]).Trim();
            _Cliente.TaxIdentificationNumber = _CamposReg[4];

            if (!string.IsNullOrWhiteSpace(_CamposReg[5]))
            {
                _FacturaActual.CountryCode = _CamposReg[5];
            }
            _FacturaActual.SellerParty = _Cliente;

            // En el caso de que se trate de un cliente extranjero, habremos informado este campo, de manera que podremos indicar 
            // el código de país correspondiente

            _FacturaActual.OperationType = _CamposReg[11];
            _FacturaActual.ClaveDeclarado = _CamposReg[12];
            _FacturaActual.EstadoMiembro = _CamposReg[13];
            _FacturaActual.DescripcionBienes = _CamposReg[14];
            _FacturaActual.DireccionOperador = _CamposReg[15];

            return _FacturaActual;
        }

    }
}
