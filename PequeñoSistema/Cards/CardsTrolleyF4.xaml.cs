using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using PequeñoSistema.Clases;
using PequeñoSistema.Pages;
using PequeñoSistema.Mensajes;

namespace PequeñoSistema.Cards
{
    /// <summary>
    /// Lógica de interacción para CardsTrolleyF4.xaml
    /// </summary>
    [DefaultEvent("_TextChanged")]
    public partial class CardsTrolleyF4 : UserControl
    {
       // public static bool VerDetalles = false;
        private string NombrePastel;
        private int CantidadPasteles;
        private decimal Precio;
        private string Ruta;
        private string Boton;

        public CardsTrolleyF4()
        {
            InitializeComponent();
        }

        [Category("Universo F4")]
        public string nombrePastel
        {
            get
            {
                return this.NombrePastel;
            }
            set
            {
                txtNamePas.Text = nombrePastel;
                this.txtNamePas.Text = value;
            }
        }

        [Category("Universo F4")]
        public decimal precioPastel
        {
            get
            {
                return this.Precio;
            }
            set
            {
                this.Precio = value;
            }
        }

        [Category("universo F4")]
        public int cantidadPasteles
        {
            get
            {
                return this.CantidadPasteles;
            }
            set
            {
                this.CantidadPasteles = value;
            }
        }

        [Category("Universo F4")]
        public string ImagenFondo
        {
            get
            {
                return Ruta;
            }
            set
            {
                Ruta = value;
            }
        }

        public static void EliminarProducto()
        {
            try
            {
                for (int i = 0; i < TotalPedidos.ID.Count; i++)
                {
                    if (MensajeDelete.NombreID == "btnDelete" + TotalPedidos.ID[i])
                    {
                        TotalPedidos.ID.RemoveAt(i);
                        TotalPedidos.Nombre.RemoveAt(i);
                        TotalPedidos.Tamaño.RemoveAt(i);
                        TotalPedidos.Ingredientes.RemoveAt(i);
                        TotalPedidos.Anotaciones.RemoveAt(i);
                        TotalPedidos.Cantidad.RemoveAt(i);
                        TotalPedidos.PrecioT.RemoveAt(i);
                        TotalPedidos.Imagen.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarVentana()
        {
            try
            {
                MensajeDelete.NombreID = btnDelete.Name;
                MensajeDelete msj = new MensajeDelete();
                msj.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MostrarVentana();
        }

        private void btnView_MouseLeave(object sender, MouseEventArgs e)
        {
            btnView.Visibility = Visibility.Collapsed;
        }

        private void ImgContent_MouseEnter(object sender, MouseEventArgs e)
        {
            btnView.Visibility = Visibility.Visible;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btnView.Visibility = Visibility.Collapsed;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            MostrarVentana();
        }
    }
}
