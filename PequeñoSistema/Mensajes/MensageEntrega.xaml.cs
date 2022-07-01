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
using PequeñoSistema.DB;
using PequeñoSistema.Clases;
using PequeñoSistema.Ventana;
using PequeñoSistema.Pages;

namespace PequeñoSistema.Mensajes
{
    /// <summary>
    /// Lógica de interacción para MensageEntrega.xaml
    /// </summary>
    public partial class MensageEntrega : Window
    {
        public MensageEntrega()
        {
            InitializeComponent();
        }

        private void btnSi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntregarPedido enp = new DBEntregarPedido();
                enp.Entregar();

                PageOrderList.ActualizarVista();

                for (int i = 0; i < ListaDePedidos.NPedido.Count; i++)
                {
                    if (OrderDetails.Codigo == ListaDePedidos.NPedido[i].ToString())
                    {
                        ListaDePedidos.Cliente.RemoveAt(i);
                        ListaDePedidos.NPedido.RemoveAt(i);
                        ListaDePedidos.Descripcion.RemoveAt(i);
                        ListaDePedidos.FEntrega.RemoveAt(i);
                        ListaDePedidos.Precio.RemoveAt(i);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
