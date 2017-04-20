using System;
using System.IO;
using System.Windows.Forms;

namespace Sample
{
    class GenerarFicheros
    {

        public void GeneraFicheros(string _NomFichero)
        {
            if (File.Exists(_NomFichero))
            {
                string _TrabajarCon = "CORE";
                //string _TrabajarCon = "BUSI";

                // Leeremos la primera línea del fichero, en la que hay un campo que indica el tipo
                // de facturas que contiene. Posteriormente, llamaremos a la función correspondiente
                // para generar el XML correcto.
                StreamReader _Lector = new StreamReader(_NomFichero);
                string _Cabecera = _Lector.ReadLine();
                _Lector.Close();

                string[] _CamposReg = _Cabecera.Split(';');
                string _TipoFichero = _CamposReg[4];

                switch (_TipoFichero)
                {
                    case "EMI":
                        {
                            
                            if (_TrabajarCon == "CORE")
                            {
                                EmitidasEnvel FuncionesEmiEnvel = new EmitidasEnvel();
                                FuncionesEmiEnvel.GenerarXMLEmitidasEnvel(_NomFichero);
                            } else
                            {
                                Emitidas FuncionesEmi = new Emitidas();
                                FuncionesEmi.GenerarXMLEmitidas(_NomFichero);
                            }
                            break;
                        }
                    case "REC":
                        {
                            if (_TrabajarCon == "CORE")
                            {
                                RecibidasEnvel FuncionesRecEnvel = new RecibidasEnvel();
                                FuncionesRecEnvel.GenerarXMLRecibidasEnvel(_NomFichero);
                            }
                            else
                            {
                                Recibidas FuncionesRec = new Recibidas();
                                FuncionesRec.GenerarXMLRecibidas(_NomFichero);
                            }
                            break;
                        }
                    case "INT":
                        {
                            if (_TrabajarCon == "CORE")
                            {
                                IntracomEnvel FuncionesIntEnvel = new IntracomEnvel();
                                FuncionesIntEnvel.GenerarXMLIntracomEnvel(_NomFichero);
                            }
                            else
                            {
                                Intracom FuncionesInt = new Intracom();
                                FuncionesInt.GenerarXMLIntracom(_NomFichero);
                            }
                            break;
                        }
                    default:
                        {
                            string _msg = "Este fichero no se puede tratar en este programa";
                            MessageBox.Show(_msg, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                }
            }
            else {
                string _msg = "El fichero indicado no existe";
                MessageBox.Show(_msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
