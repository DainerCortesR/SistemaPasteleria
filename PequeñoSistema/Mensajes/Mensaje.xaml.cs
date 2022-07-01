using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PequeñoSistema.Pages;
using PequeñoSistema.Clases;
using PequeñoSistema.Cards;

namespace PequeñoSistema.Mensajes
{
    /// <summary>
    /// Lógica de interacción para MensajeDelete.xaml
    /// </summary>
    public partial class Mensaje : Window
    {
        public static string mensaje = "";

        public static string Msg1;
        public static string Msg2;
        public Mensaje()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mensaje == "CompraRealizada")
                {
                    PageTrolley.ActualizarVista();
                    EnviarCorreo send = new EnviarCorreo();
                    send.EnviarCorreoPDF();
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            msg1.Text = Msg1;
            msg2.Text = Msg2;

            //msg1.HorizontalAlignment = HorizontalAlignment.Center;
            //msg2.HorizontalAlignment = HorizontalAlignment.Center;
        }
    }
}
