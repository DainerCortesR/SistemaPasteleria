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
using PequeñoSistema.Cards;

namespace PequeñoSistema.Mensajes
{
    /// <summary>
    /// Lógica de interacción para MensajeDelete.xaml
    /// </summary>
    public partial class MensajeDelete : Window
    {
        public static string NombreID;
        public MensajeDelete()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CardsTrolleyF4.EliminarProducto();
                PageTrolley.ActualizarVista();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
    }
}
