using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Caliburn.Micro;
using PequeñoSistema.Clases;
using PequeñoSistema.DB;
using PequeñoSistema.Ventana;

namespace PequeñoSistema.Pages
{
    /// <summary>
    /// Lógica de interacción para PageOrderList.xaml
    /// </summary>
    public partial class PageOrderList : Page
    {
        DBPedidos dbp = new DBPedidos();
        public static DispatcherTimer timer = new DispatcherTimer();

        public PageOrderList()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        public class Pedidos
        {
            // public int ID;
            public string Cliente { get; set; }
            public string NPedido { get; set; }
            public string FEntrega { get; set; }
            public decimal Costo { get; set; }
        }

        private void ListaPedidos()
        {
            try
            {
                dgUsers.ItemsSource = null;

                List<Pedidos> users = new List<Pedidos>();

                for (int i = 0; i < ListaDePedidos.NPedido.Count; i++)
                {
                    users.Add(new Pedidos()
                    {
                        Cliente = Convert.ToString(ListaDePedidos.Cliente[i]),
                        NPedido = Convert.ToString(ListaDePedidos.NPedido[i]),
                        FEntrega = Convert.ToString(ListaDePedidos.FEntrega[i]),
                        Costo = Convert.ToDecimal(ListaDePedidos.Precio[i])
                    });
                }

                dgUsers.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Usuario.Administrador != "no")
                {
                    dbp.Pedidos();
                }
                else
                {
                    dbp.PedidosUser();
                }

                ListaPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void dgUsers_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Pedidos pd = (Pedidos)dgUsers.SelectedItem;
                OrderDetails.Codigo = pd.NPedido;

                OrderDetails ord = new OrderDetails();
                ord.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Buscar()
        {
            try
            {
                if (Usuario.Administrador != "no")
                {
                    dbp.BuscarPedido(txtBuscar.Text);
                    ListaPedidos();
                }
                else
                {
                    dbp.BuscarPedidoUser(txtBuscar.Text);
                    ListaPedidos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void imgBuscar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Buscar();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Start();
                ListaPedidos();
                timer.Stop();
            }
            catch (Exception ex)
            {
                timer.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        public static void ActualizarVista()
        {
            timer.Start();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Buscar();
            }
        }
    }
}
