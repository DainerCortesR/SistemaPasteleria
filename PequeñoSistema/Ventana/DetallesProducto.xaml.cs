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
    /// Lógica de interacción para DetallesProducto.xaml
    /// </summary>
    public partial class DetallesProducto : Window
    {
        public int IdP;
        public string TamañoP;
        public string IngredientesP;
        public string ImagenP;

        public static string OcultarBoton;
        public static string btnCompra;
        public int Cantidad = 1;
        public int PrecioBase;
        public int PrecioNuevo;

        public DetallesProducto()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < TotalProductos.ListID.Count; i++)
                {
                    if (btnCompra == "btnComprar" + TotalProductos.ListID[i])
                    {
                        IdP = Convert.ToInt32(TotalProductos.ListID[i]);
                        TamañoP = Convert.ToString(TotalProductos.ListTamaño[i]);
                        IngredientesP = Convert.ToString(TotalProductos.ListIngredientes[i]);
                        ImagenP = Convert.ToString(TotalProductos.ListImagen[i]);

                        lblNombre.Text = Convert.ToString(TotalProductos.ListNombre[i]);
                        lblTamaño.Text = "Tamaño: " + TamañoP;
                        lblIngredientes.Text = "Ingredientes: " + IngredientesP;
                        lblCantidad.Text = "Cantidad " + Cantidad;
                        PrecioBase = Convert.ToInt32(TotalProductos.ListPrecio[i]);
                        lblPrecio.Text = "Precio: $" + PrecioBase;
                        PrecioNuevo = PrecioBase;

                        var fullFilePath = ImagenP;

                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                        bitmap.EndInit();

                        picImage.Source = bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void imgMenos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Cantidad > 1)
                {
                    Cantidad -= 1;
                    PrecioNuevo -= PrecioBase;
                    lblCantidad.Text = "Cantidad " + Cantidad;
                    lblPrecio.Text = "Precio: $" + PrecioNuevo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void imgMas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Cantidad < 5)
                {
                    Cantidad += 1;
                    PrecioNuevo += PrecioBase;
                    lblCantidad.Text = "Cantidad " + Cantidad;
                    lblPrecio.Text = "Precio: $" + PrecioNuevo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lblFecha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            bool continuar = true;

            try
            {
                if (this.txtAnotaciones.Text.Trim() == "")
                {
                    this.txtAnotaciones.BorderBrush = Brushes.Red;
                }
                if (this.txtAnotaciones.Text.Trim() != "")
                {
                    if (TotalPedidos.ID.Count == 0)
                    {
                        continuar = true;
                    }
                    else
                    {
                        for (int i = 0; i < TotalPedidos.ID.Count; i++)
                        {
                            if (TotalPedidos.ID[i] == IdP)
                            {
                                continuar = false;
                                break;
                            }

                        }
                    }
                    if (continuar == true)
                    {
                        TotalPedidos.ID.Add(IdP);
                        TotalPedidos.Nombre.Add(lblNombre.Text);
                        TotalPedidos.Tamaño.Add(TamañoP);
                        TotalPedidos.Ingredientes.Add(IngredientesP);
                        TotalPedidos.Cantidad.Add(Cantidad);
                        TotalPedidos.PrecioT.Add(PrecioNuevo);
                        TotalPedidos.Imagen.Add(ImagenP);
                        TotalPedidos.Anotaciones.Add(txtAnotaciones.Text);
                    }
                    else
                    {
                        Mensaje.mensaje = "";
                        Mensaje.Msg1 = "Error al continuar";
                        Mensaje.Msg2 = "Este producto ya fue añadido";

                        Mensaje msg = new Mensaje();
                        msg.ShowDialog();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAnotaciones_MouseEnter(object sender, MouseEventArgs e)
        {
            this.txtAnotaciones.BorderBrush = Brushes.Black;
        }
    }
}
