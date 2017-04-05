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
                ITInvoicesBatch _LoteOperIntracom = new ITInvoicesBatch();
                ITInvoice _OperIntracomAct = new ITInvoice();
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
                                    _OperIntracomAct = new ITInvoice();
                                    _OperIntracomAct = funcion.TratarOperIntracom(_CamposReg, _Titular);
                                    _LoteOperIntracom.ITInvoices.Add(_OperIntracomAct);
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
        private ITInvoice TratarOperIntracom(string[] _CamposReg, Party _Titular)
        {
            ITInvoice _FacturaActual = new ITInvoice();
            Party _Emisor = new Party();
            Party _Receptor = new Party();

            // Por las pruebas que hemos podido realizar, en el SoapUI, dependiendo de si se trata de una factura intracomunitaria emitida o recibida
            // el emisor de la misma será o el titular o el proveedor/acreedor que nos haya remitido la factura. En nuestro caso, al tratarse de facturas
            // recibidas, el emisor de la misma será el proveedor/acreedor. Procedemos a modificar el código para que se genere correctamente el lote.
            //
            // Informamos el Proveedor/Acreedor en nuestro caso.
            _Emisor.PartyName = (_CamposReg[3]).Trim();
            _Emisor.TaxIdentificationNumber = _CamposReg[4];

            if (!string.IsNullOrWhiteSpace(_CamposReg[5]))
            {
                _FacturaActual.CountryCode = _CamposReg[5];
            }
            _FacturaActual.BuyerParty = _Emisor;

            // Procedemos a tratar la factura actual.
            //El periodo impositivo no lo informamos, ya que se informará automáticamente a partir
            // de la fecha de la factura, según las pruebas que hemos realizado.
            _FacturaActual.InvoiceNumber = (_CamposReg[7]).Trim();
            _FacturaActual.IssueDate = Convert.ToDateTime(_CamposReg[8]);

            // Informamos la contraparte de la factura, que en nuestro caso se trata del titular del lote.
            _Receptor = _Titular;
            _FacturaActual.SellerParty = _Receptor;

            // En el caso de que se trate de un cliente extranjero, habremos informado este campo, de manera que podremos indicar 
            // el código de país correspondiente

            OperationType operationType;

            if (!Enum.TryParse<OperationType>(_CamposReg[11], out operationType))
                MessageBox.Show($"El tipo de operación { _CamposReg[11]} es deconocido.");

            _FacturaActual.OperationType = operationType;

            ClaveDeclarado claveDeclarado;

            if (!Enum.TryParse<ClaveDeclarado>(_CamposReg[12], out claveDeclarado))
                MessageBox.Show($"La clave declarado {_CamposReg[12]} es desconocido.");
            _FacturaActual.ClaveDeclarado = claveDeclarado;

            _FacturaActual.EstadoMiembro = _CamposReg[13];
            _FacturaActual.DescripcionBienes = _CamposReg[14];
            _FacturaActual.DireccionOperador = _CamposReg[15];

            return _FacturaActual;
        }

    }
}
