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
    class Recibidas
    {

        public void GenerarXMLRecibidas(string _NombreFichero)
        {

            Recibidas funcion = new Recibidas();
            string _NomFicheroWrk = _NombreFichero;
            try
            {
                APInvoicesBatch _LoteFactRecibidas = new APInvoicesBatch();
                APInvoice _FactRecibidaAct = new APInvoice();
                Party _Titular = new Party();
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
                                    _Titular = funcion.TratarRegCabecera(_CamposReg);
                                    _LoteFactRecibidas.Titular = _Titular;
                                    string _TipoComunicacion = _CamposReg[3];
                                    switch (_TipoComunicacion)
                                    {
                                        case "A0":
                                            _LoteFactRecibidas.CommunicationType = CommunicationType.A0;
                                            break;
                                        case "A1":
                                            _LoteFactRecibidas.CommunicationType = CommunicationType.A1;
                                            break;
                                        case "A4":
                                            _LoteFactRecibidas.CommunicationType = CommunicationType.A4;
                                            break;
                                    }
                                    break;
                                case "FACT":
                                    if (_NuevaFact) // Si se trata de una nueva factura, añadiremos la 'antigua' al fichero
                                    {
                                        _LoteFactRecibidas.APInvoices.Add(_FactRecibidaAct);
                                        _NuevaFact = false;
                                    }
                                    _FactRecibidaAct = new APInvoice();
                                    _FactRecibidaAct = funcion.TratarFactRecibida(_CamposReg, _Titular);
                                    break;
                                case "RECT":
                                    _FactRecibidaAct = funcion.AgregarFactRectifica(_CamposReg, _FactRecibidaAct);
                                    break;
                                case "FISC":
                                    _NuevaFact = true;
                                    _FactRecibidaAct = funcion.AgregarDesgloseIVA(_CamposReg, _FactRecibidaAct);
                                    break;
                                case "FINI":
                                    // Tenemos que grabar la última factura tratada, ya que sino no se incluirá en el XML
                                    _LoteFactRecibidas.APInvoices.Add(_FactRecibidaAct);

                                    // Procedemos a generar el XML final.
                                    DateTime _FechaActual = DateTime.Today; //Obtenemos la fecha actual sin la hora
                                    string nombrefichero = "SII_Recibidas_" + _Titular.TaxIdentificationNumber + "_" + _FechaActual.ToString("yyyyMMdd") + ".XML";
                                    string XmlResult = "C:/Temp/" + nombrefichero;
                                    _LoteFactRecibidas.GetXml(XmlResult);

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

        /// <summary>
        /// Función para tratar el registro de factura que se acaba de leer. 
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_Titular"></param>
        /// <returns></returns>
        private APInvoice TratarFactRecibida(string[] _CamposReg, Party _Titular)
        {
            APInvoice _FacturaActual = new APInvoice();
            Party _Emisor = new Party();

            // Al tratarse de una factura recidida el emisor será el Proveedor.
            _Emisor.PartyName = _CamposReg[12].Trim();
            _Emisor.TaxIdentificationNumber = _CamposReg[3];
            _FacturaActual.SellerParty = _Emisor;

            // En el caso de que se trate de un Proveedor extranjero, habremos informado este campo, de manera que podremos indicar 
            // el código de país correspondiente
            if (!string.IsNullOrWhiteSpace(_CamposReg[4]))
            {
                _FacturaActual.CountryCode = _CamposReg[4];
            }

            // Procedemos a tratar la factura actual.
            //El periodo impositivo no lo informamos, ya que se informará automáticamente a partir
            // de la fecha de la factura, según las pruebas que hemos realizado.
            _FacturaActual.InvoiceNumber = (_CamposReg[6]).Trim();
            _FacturaActual.IssueDate = Convert.ToDateTime(_CamposReg[7]);
            if (string.IsNullOrWhiteSpace(_CamposReg[11]))
            {
                _CamposReg[11] = "Hay que informar el concepto de la factura";
            }
            _FacturaActual.InvoiceText = (_CamposReg[11]).Trim();

            string _TipoFactura = _CamposReg[8];
            switch (_TipoFactura)
            {
                case "F1":
                    _FacturaActual.InvoiceType = InvoiceType.F1;
                    break;
                case "F2":
                    _FacturaActual.InvoiceType = InvoiceType.F2;
                    break;
                case "F3":
                    _FacturaActual.InvoiceType = InvoiceType.F3;
                    break;
                case "F4":
                    _FacturaActual.InvoiceType = InvoiceType.F4;
                    break;
                case "R1":
                    _FacturaActual.InvoiceType = InvoiceType.R1;
                    break;
                case "R2":
                    _FacturaActual.InvoiceType = InvoiceType.R2;
                    break;
                case "R3":
                    _FacturaActual.InvoiceType = InvoiceType.R3;
                    break;
                case "R4":
                    _FacturaActual.InvoiceType = InvoiceType.R4;
                    break;
                case "R5":
                    _FacturaActual.InvoiceType = InvoiceType.R5;
                    break;
            }

            int _ClaveTras = Convert.ToInt16(_CamposReg[9]);
            _FacturaActual.ClaveRegimenEspecialOTrascendencia = (EasySII.Business.ClaveRegimenEspecialOTrascendencia)_ClaveTras;

            _FacturaActual.GrossAmount = Convert.ToDecimal(_CamposReg[10]);

            // Informamos el receptor. Según pruebas con el SOAP, este debe coincidir con el emisor.
            _FacturaActual.BuyerParty = _Emisor;

            _FacturaActual.PostingDate = Convert.ToDateTime(_CamposReg[13]);
            _FacturaActual.OperationIssueDate = Convert.ToDateTime(_CamposReg[17]);

            //En este trozo procedemos a tratar las facturas rectificativas.
            if (!string.IsNullOrWhiteSpace(_CamposReg[14]))
            {
                string TipoRectifica = _CamposReg[14];
                switch (TipoRectifica)
                {
                    case "I":
                        _FacturaActual.RectifiedType = RectifiedType.I;
                        break;
                    case "S":
                        _FacturaActual.RectifiedType = RectifiedType.S;
                        break;
                }

                _FacturaActual.RectifiedBase = Convert.ToDecimal(_CamposReg[15]);
                _FacturaActual.RectifiedAmount = Convert.ToDecimal(_CamposReg[16]);
            }

            return _FacturaActual;
        }

        /// <summary>
        /// Rutina para añadir los desgloses de IVA correspondientes por cada factura.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>

        private APInvoice AgregarDesgloseIVA(string[] _CamposReg, APInvoice _FacturaActual)
        {
            // Procedemos a tratar la factura actual.
            // En este caso añadiremos las líneas de fiscalidad que hayamos leido a la factura que estemos tratando en ese momento

            string TipoInversion = _CamposReg[2];
            switch (TipoInversion)
            {
                case "S1":
                    _FacturaActual.IsInversionSujetoPasivo = false;
                    break;
                case "S2":
                    _FacturaActual.IsInversionSujetoPasivo = true;
                    break;
            }

            decimal _TipoImpos, _BaseImpos, _CuotaImpos;
            _TipoImpos = Convert.ToDecimal(_CamposReg[3]);
            _BaseImpos = Convert.ToDecimal(_CamposReg[4]);
            _CuotaImpos = Convert.ToDecimal(_CamposReg[5]);

            _FacturaActual.AddTaxOtuput(_TipoImpos, _BaseImpos, _CuotaImpos);

            return _FacturaActual;
        }

        /// <summary>
        /// Rutina para añadir las facturas rectificadas, en el caso de que estas lleguen informadas.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>

        private APInvoice AgregarFactRectifica(string[] _CamposReg, APInvoice _FacturaActual)
        {

            InvoiceRectified factRectifica = new InvoiceRectified();
            factRectifica.RectifiedInvoiceNumber = (_CamposReg[1]).Trim();
            factRectifica.RectifiedIssueDate = Convert.ToDateTime(_CamposReg[2]);

            _FacturaActual.InvoicesRectified.Add(factRectifica);

            return _FacturaActual;
        }

    }
}
