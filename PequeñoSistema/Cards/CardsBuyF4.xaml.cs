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
using PequeñoSistema.Ventana;

namespace PequeñoSistema.Cards
{
    /// <summary>
    /// Lógica de interacción para CardsBuyF4.xaml
    /// </summary>
    [DefaultEvent("_TextChanged")]
    public partial class CardsBuyF4 : UserControl
    {
        public static bool VerDetalles = false;
        private string NombrePastel;
        private decimal Precio;
        private string Ruta;
        private string Boton;

        public CardsBuyF4()
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

        private void AbrirVentana()
        {
            try
            {
                DetallesProducto.btnCompra = btnComprar.Name;
                DetallesProducto dtp = new DetallesProducto();
                dtp.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            AbrirVentana();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            AbrirVentana();
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
    }
}
