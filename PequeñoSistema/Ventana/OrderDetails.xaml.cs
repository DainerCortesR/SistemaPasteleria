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
using PequeñoSistema.Clases;
using PequeñoSistema.Mensajes;

namespace PequeñoSistema.Ventana
{
    /// <summary>
    /// Lógica de interacción para OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        public static string Codigo;

        public OrderDetails()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Usuario.Administrador.Trim() != "yes")
                {
                    btnDeliver.Visibility = Visibility.Collapsed;
                    btnReturn.Margin = new Thickness(275, 20, 0, 0);
                }
                else
                {
                    btnDeliver.Visibility = Visibility.Visible;
                    btnReturn.Margin = new Thickness(50, 20, 0, 0);
                }

                for (int i = 0; i < ListaDePedidos.NPedido.Count; i++)
                {
                    if (Codigo == ListaDePedidos.NPedido[i].ToString())
                    {
                        lblContent.Text = ListaDePedidos.Descripcion[i].ToString();
                    }
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void btnDeliver_Click(object sender, RoutedEventArgs e)
        {
            MensageEntrega mse = new MensageEntrega();
            this.Hide();
            mse.ShowDialog();
            this.Close();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
