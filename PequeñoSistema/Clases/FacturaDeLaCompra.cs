using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using PequeñoSistema.Clases;
using System.Windows;

namespace PequeñoSistema.Clases
{
    public class FacturaDeLaCompra
    {
        private Random rnd = new Random();
        DateTime Dtf = DateTime.Now;
        public static string FEntrega = "";
        public static string CodigoF;
        public static decimal total = 0;

        public void CrearFacturaPDF()
        {
            try
            {
                string paginaHtml = Properties.Resources.FacturaPasteleria.ToString();

                string descripcion = string.Empty;

                CodigoF += rnd.Next(1, 9);

                for (int i = 0; i < 7; i++)
                {
                    CodigoF += rnd.Next(0, 9);
                }
                for (int i = 0; i < TotalPedidos.ID.Count; i++)
                {
                    descripcion += TotalPedidos.Cantidad[i] + " ";
                    descripcion += TotalPedidos.Nombre[i] + ", ";

                    total += TotalPedidos.PrecioT[i];
                }
                paginaHtml = paginaHtml.Replace("@NPAGO", "<b>Número de pago: <h2>" + CodigoF + "</h2></b>");
                paginaHtml = paginaHtml.Replace("@TOTALP", "<br/><b>Total a pagar: $ " + total.ToString() + "</b>");
                paginaHtml = paginaHtml.Replace("@FECHAP", "<b>Paga antes de:</b><br/>" + Dtf.AddDays(1).ToLongDateString());
                paginaHtml = paginaHtml.Replace("@FECHAC", Dtf.ToLongDateString());
                paginaHtml = paginaHtml.Replace("@DATOSCOMPRA", descripcion);
                paginaHtml = paginaHtml.Replace("@DATOSPAGADOR", "<b>Nombre: </b>" + Usuario.Nombre + " " + Usuario.Apellidos + "<br /><b>Correo: </b>" + Usuario.Correo);
                //  paginaHtml = paginaHtml.Replace("@TOTAL", total.ToString());

                // Indicamos donde vamos a guardar el documento
                Document docc = new Document(PageSize.LETTER);
                using (FileStream stream = new FileStream(@"C:\CachePasteleria\" + CodigoF + ".pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    pdfDoc.Add(new Phrase(""));


                    using (StringReader sr = new StringReader(paginaHtml))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
    }
}
