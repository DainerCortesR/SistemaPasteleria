using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PequeñoSistema.Clases;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.IO;

namespace PequeñoSistema.Clases
{
    class EnviarCorreo
    {
        private string EmailOrigen;
        private string Contraseña;
        private string EmailDestino;
        private string PDF;

        public EnviarCorreo()
        {
            EmailOrigen = "pasteleriaelpalaciodelsabor@gmail.com";
            Contraseña = "tiendadepasteles";
            EmailDestino = Usuario.Correo;
            PDF = @"C:\CachePasteleria\" + FacturaDeLaCompra.CodigoF + ".pdf";
        }

        public void EnviarCorreoPDF()
        {
            try
            {
                MailMessage iMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Factura de la compra", "Gracias por comprar en nuestra tienda");
                iMailMessage.Attachments.Add(new Attachment(PDF));
                iMailMessage.IsBodyHtml = true;

                SmtpClient ismtpClient = new SmtpClient("smtp.gmail.com");
                ismtpClient.EnableSsl = true;
                ismtpClient.UseDefaultCredentials = false;
                ismtpClient.Port = 587;
                ismtpClient.Credentials = new NetworkCredential(EmailOrigen, Contraseña);
                ismtpClient.Send(iMailMessage);
                ismtpClient.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
