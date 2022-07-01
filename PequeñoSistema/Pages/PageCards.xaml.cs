using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using MaterialDesignThemes.Wpf;
using PequeñoSistema.Cards;
using PequeñoSistema.DB;
using PequeñoSistema.Clases;

namespace PequeñoSistema.Pages
{
    /// <summary>
    /// Lógica de interacción para PageCards.xaml
    /// </summary>
    public partial class PageCards : Page
    {
        private string Nombre = "Card";
        DBProductos pdr = new DBProductos();

        public PageCards()
        {
            InitializeComponent();
        }

        private void PageCards_Loaded(object sender, RoutedEventArgs e)
        {
            pdr.Productoss();
            this.Cards();
        }

        private void Cards()
        {
            try
            {
                PanelCards.Children.Clear();

                CardsBuyF4 obj;

                for (int i = 0; i < TotalProductos.ListID.Count; i++)
                {
                    Nombre += Convert.ToString(TotalProductos.ListID[i]);

                    obj = new CardsBuyF4();
                    obj.Name = Nombre;

                    obj.nombrePastel = Convert.ToString(TotalProductos.ListNombre[i]);
                    obj.precioPastel = Convert.ToDecimal(TotalProductos.ListPrecio[i]);
                    obj.txtPrecio.Text = "Precio: $" + obj.precioPastel;

                    var fullFilePath = Convert.ToString(TotalProductos.ListImagen[i]);

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();

                    obj.ImgContent.Source = bitmap;
                    obj.btnComprar.Name += Convert.ToString(TotalProductos.ListID[i]);
                    //    obj.btnVer.Name += Convert.ToString(TotalProductos.ListID[i]);

                    PanelCards.Children.Add(obj);
                }
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
                pdr.BuscarProductos(this.txtBuscar.Text);
                this.Cards();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Buscar();
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
