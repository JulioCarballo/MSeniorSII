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
    class Emitidas
    {

        bool _NuevaFact = false;
        int lineas = 0;

        public void GenerarXMLEmitidas(string _NombreFichero)
        {

            Emitidas funcion = new Emitidas();
            string _NomFicheroWrk = _NombreFichero;
            try
            {
                ARInvoicesBatch _LoteFactEmitidas = new ARInvoicesBatch();
                ARInvoice _FactEmitidaAct = new ARInvoice();
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
                                    lineas++;
                                    _Titular = funcion.TratarRegCabecera(_CamposReg);
                                    _LoteFactEmitidas.Titular = _Titular;

                                    // Con esto ya no hace falta tener que obtener el valor del campo y posteriormente tener que revisar que valor ponemos en cada
                                    // caso con un switch. Ahorramos líneas de código.
                                    _LoteFactEmitidas.CommunicationType = (CommunicationType)Enum.Parse(typeof(CommunicationType), _CamposReg[3]);

                                    break;
                                case "FACT":
                                    lineas++;
                                    if (_NuevaFact) // Si se trata de una nueva factura, añadiremos la 'antigua' al fichero
                                    {
                                        _LoteFactEmitidas.ARInvoices.Add(_FactEmitidaAct);
                                        _NuevaFact = false;
                                    }

                                    // Se trata de una factura no Sujeta, de manera que no tendrá registros 'FISC' y se tendrá que añadir a
                                    // la lista correspondiente. 
                                    if (!string.IsNullOrWhiteSpace(_CamposReg[19]) || !string.IsNullOrWhiteSpace(_CamposReg[20]))
                                        _NuevaFact = true;

                                    _FactEmitidaAct = new ARInvoice();
                                    _FactEmitidaAct = funcion.TratarFactEmitida(_CamposReg, _Titular);
                                    break;
                                case "RECT":
                                    lineas++;
                                    _FactEmitidaAct = funcion.AgregarFactRectifica(_CamposReg, _FactEmitidaAct);
                                    break;
                                case "FISC":
                                    lineas++;
                                    _NuevaFact = true;
                                    _FactEmitidaAct = funcion.AgregarDesgloseIVA(_CamposReg, _FactEmitidaAct);
                                    break;
                                case "FINI":
                                    lineas++;
                                    // Tenemos que grabar la última factura tratada, ya que sino no se incluirá en el XML
                                    _LoteFactEmitidas.ARInvoices.Add(_FactEmitidaAct);

                                    // Procedemos a generar el XML final.
                                    DateTime _FechaActual = DateTime.Today; //Obtenemos la fecha actual sin la hora
                                    string nombrefichero = "SII_Emitidas_" + _Titular.TaxIdentificationNumber + "_" + _FechaActual.ToString("yyyyMMdd") + ".XML";
                                    string XmlResult = "C:/Temp/" + nombrefichero;
                                    _LoteFactEmitidas.GetXml(XmlResult);

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
                string _msgError = "Error: " + ex.Message + "(linea: " + lineas +")";
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
        private ARInvoice TratarFactEmitida(string[] _CamposReg, Party _Titular)
        {
            ARInvoice _FacturaActual = new ARInvoice();
            Party _Emisor, _Cliente = new Party();

            // Al tratarse de una factura emitida el Vendedor (Seller - _Emisor) será el mismo que el Titular del libro.
            _Emisor = _Titular;
            _FacturaActual.SellerParty = _Emisor;

            // Procedemos a tratar la factura actual.
            //El periodo impositivo no lo informamos, ya que se informará automáticamente a partir
            // de la fecha de la factura, según las pruebas que hemos realizado.
            _FacturaActual.InvoiceNumber = (_CamposReg[4]).Trim();

            // En caso de que se trate de una factura de Asiento Resumen, hay que informar la última factura
            // que se incluye en este envío.
            if (!string.IsNullOrWhiteSpace(_CamposReg[14]))
            {
                _FacturaActual.InvoiceNumberLastItem = _CamposReg[14];
            }

            _FacturaActual.IssueDate = Convert.ToDateTime(_CamposReg[5]);
            if (string.IsNullOrWhiteSpace(_CamposReg[9]))
            {
                _CamposReg[9] = "Hay que informar el concepto de la factura";
            }
            _FacturaActual.InvoiceText = (_CamposReg[9]).Trim();

            // Procedemos a indicar el tipo de factura, que dependerá de lo que venga indicado en el fichero
            _FacturaActual.InvoiceType = (InvoiceType)Enum.Parse(typeof(InvoiceType),_CamposReg[6]);

            // Procedemos a indicar el tipo de ClaveRegimenEspecial respecto a lo que venga indicado en el fichero
            _FacturaActual.ClaveRegimenEspecialOTrascendencia = (ClaveRegimenEspecialOTrascendencia)Enum.Parse(typeof(ClaveRegimenEspecialOTrascendencia),_CamposReg[7]);

            _FacturaActual.GrossAmount = Convert.ToDecimal(_CamposReg[8]);

            if (!string.IsNullOrWhiteSpace(_CamposReg[15]))
            {
                _FacturaActual.OperationIssueDate = Convert.ToDateTime(_CamposReg[15]);
            }

            // Informamos el cliente.
            _Cliente.PartyName = (_CamposReg[10]).Trim();
            _Cliente.TaxIdentificationNumber = _CamposReg[11];
            _FacturaActual.BuyerParty = _Cliente;

            // En el caso de que se trate de un cliente extranjero, habremos informado este campo, de manera que podremos indicar 
            // el código de país correspondiente
            if (!string.IsNullOrWhiteSpace(_CamposReg[12]))
            {
                _FacturaActual.CountryCode = _CamposReg[12];
            }

            //En este trozo procedemos a tratar las facturas rectificativas.
            if (!string.IsNullOrWhiteSpace(_CamposReg[16]))
            {
                _FacturaActual.RectifiedType = (RectifiedType)Enum.Parse(typeof(RectifiedType), _CamposReg[16]);
                _FacturaActual.RectifiedBase = Convert.ToDecimal(_CamposReg[17]);
                _FacturaActual.RectifiedAmount = Convert.ToDecimal(_CamposReg[18]);
            }

            // Procedemos a tratar el caso de que se trate del deslgose no Sujeto
            TipoDesglose tipoDesglose = new TipoDesglose();
            DesgloseFactura desgloseFactura = new DesgloseFactura();
            NoSujeta noSujeta = new NoSujeta();

            if (!string.IsNullOrWhiteSpace(_CamposReg[19]) || !string.IsNullOrWhiteSpace(_CamposReg[20]))
            {
                if (!string.IsNullOrWhiteSpace(_CamposReg[19]))
                    noSujeta.ImportePorArticulos7_14_Otros = ((_CamposReg[19]).Trim()).Replace(',', '.');

                if (!string.IsNullOrWhiteSpace(_CamposReg[20]))
                    noSujeta.ImporteTAIReglasLocalizacion = ((_CamposReg[20]).Trim()).Replace(',', '.');

                desgloseFactura.NoSujeta = noSujeta;

                tipoDesglose.DesgloseFactura = desgloseFactura;

                //_FacturaActual.InnerSII.FacturaExpedida.TipoDesglose = tipoDesglose;
            }

            return _FacturaActual;
        }

        /// <summary>
        /// Rutina para añadir los desgloses de IVA correspondientes por cada factura.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>

        private ARInvoice AgregarDesgloseIVA(string[] _CamposReg, ARInvoice _FacturaActual)
        {
            // Procedemos a tratar la factura actual.
            // En este caso añadiremos las líneas de fiscalidad que hayamos leido a la factura que estemos tratando en ese momento

            // En este caso, a este nivel, tampoco podemos añadir el valor correspondiente a 'TipoNoExenta'.
            string _RegImpos = _CamposReg[1];

            if (_CamposReg[6] == "S")
            {
                _FacturaActual.IsTaxExcluded = false;
                _FacturaActual.IsService = true;
            }
                

            if (_RegImpos != "E ")
            {
                _FacturaActual.Sujeta = (SujetaType)Enum.Parse(typeof(SujetaType), _CamposReg[2]);

                decimal _TipoImpos = 0;
                decimal _BaseImpos = 0;
                decimal _CuotaImpos = 0; 

                if (!string.IsNullOrWhiteSpace(_CamposReg[3]))
                {
                    _TipoImpos = Convert.ToDecimal(_CamposReg[3]);
                }

                if (!string.IsNullOrWhiteSpace(_CamposReg[4]))
                {
                    _BaseImpos = Convert.ToDecimal(_CamposReg[4]);
                }

                if (!string.IsNullOrWhiteSpace(_CamposReg[5]))
                {
                    _CuotaImpos = Convert.ToDecimal(_CamposReg[5]);
                }
                    

                _FacturaActual.AddTaxOtuput(_TipoImpos, _BaseImpos, _CuotaImpos);
            }
            else {
                _FacturaActual.CausaExencion = (CausaExencion)Enum.Parse(typeof(CausaExencion), _CamposReg[7]);
            }

            return _FacturaActual;
        }

        /// <summary>
        /// Rutina para añadir las facturas rectificadas, en el caso de que estas lleguen informadas.
        /// </summary>
        /// <param name="_CamposReg"></param>
        /// <param name="_FacturaActual"></param>
        /// <returns></returns>

        private ARInvoice AgregarFactRectifica(string[] _CamposReg, ARInvoice _FacturaActual)
        {

            InvoiceRectified factRectifica = new InvoiceRectified();
            factRectifica.RectifiedInvoiceNumber = (_CamposReg[1]).Trim();
            factRectifica.RectifiedIssueDate = Convert.ToDateTime(_CamposReg[2]);

            _FacturaActual.InvoicesRectified.Add(factRectifica);

            return _FacturaActual;
        }

    }
}
