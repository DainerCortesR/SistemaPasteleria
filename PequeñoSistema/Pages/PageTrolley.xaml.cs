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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using PequeñoSistema.Cards;
using PequeñoSistema.Clases;
using PequeñoSistema.Mensajes;
using PequeñoSistema.DB;
using PequeñoSistema.Ventana;

namespace PequeñoSistema.Pages
{
    /// <summary>
    /// Lógica de interacción para PageTrolley.xaml
    /// </summary>
    public partial class PageTrolley : Page
    {
        private string Nombre = "Cards";
        public static DispatcherTimer timer = new DispatcherTimer();

        public PageTrolley()
        {
            InitializeComponent();

     
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                timer.Start();
                this.Cards();
            }
            catch (Exception ex)
            {
                timer.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                timer.Start();
                Cards();
                LimpiarLista();
                timer.Stop();
            }
            catch (Exception ex)
            {
                timer.Stop();
                MessageBox.Show(ex.Message);
            }
        }
        private void Cards()
        {
            try
            {
                PanelCards.Children.Clear();

                CardsTrolleyF4 obj;

                for (int i = 0; i < TotalPedidos.ID.Count; i++)
                {
                    Nombre += Convert.ToString(TotalPedidos.ID[i]);

                    obj = new CardsTrolleyF4();
                    obj.Name = Nombre;

                    obj.nombrePastel = TotalPedidos.Nombre[i];
                    obj.cantidadPasteles = TotalPedidos.Cantidad[i];
                    obj.txtCantidad.Text = "Cantidad: " + obj.cantidadPasteles;
                    obj.precioPastel = TotalPedidos.PrecioT[i];
                    obj.txtPrecio.Text = "Precio: $" + obj.precioPastel;

                    var fullFilePath = TotalPedidos.Imagen[i];

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();

                    obj.ImgContent.Source = bitmap;
                    obj.btnDelete.Name += Convert.ToString(TotalPedidos.ID[i]);

                    PanelCards.Children.Add(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public static void ActualizarVista()
        {      
            timer.Start();
        }

        private void LimpiarLista()
        {
            try
            {
                if (Mensaje.mensaje == "CompraRealizada")
                {
                    TotalPedidos.ID.Clear();
                    TotalPedidos.Nombre.Clear();
                    TotalPedidos.Tamaño.Clear();
                    TotalPedidos.Ingredientes.Clear();
                    TotalPedidos.Anotaciones.Clear();
                    TotalPedidos.Cantidad.Clear();
                    TotalPedidos.PrecioT.Clear();
                    TotalPedidos.Imagen.Clear();

                    PanelCards.Children.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TotalPedidos.ID.Count != 0)
                {
                    Mensaje.Msg1 = "Compra realizada con éxito";
                    Mensaje.Msg2 = "Se envió la factura a su correo electrónico";

                    FEntrega fet = new FEntrega();
                    fet.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
