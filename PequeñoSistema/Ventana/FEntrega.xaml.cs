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
using PequeñoSistema.DB;
using PequeñoSistema.Mensajes;

namespace PequeñoSistema.Ventana
{
    /// <summary>
    /// Lógica de interacción para DetallesProducto.xaml
    /// </summary>
    public partial class FEntrega : Window
    {
        public FEntrega()
        {
            InitializeComponent();
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mensaje.mensaje = "CompraRealizada";

                if (lblFecha.Text.Trim() == "")
                {
                    lblFecha.Foreground = Brushes.Red;
                }
                else if (lblFecha.Text.Trim() != "")
                {
                    string descripcion = "";

                    for (int i = 0; i < TotalPedidos.ID.Count; i++)
                    {
                        descripcion += "Nombre: " + TotalPedidos.Nombre[i];
                        descripcion += "\nTamaño: " + TotalPedidos.Tamaño[i];
                        descripcion += "\nCantidad: " + TotalPedidos.Cantidad[i];
                        descripcion += "\nIngredientes: " + TotalPedidos.Ingredientes[i];
                        descripcion += "\nAnotaciones: " + TotalPedidos.Anotaciones[i] + "\n\n";
                    }
                    FacturaDeLaCompra.FEntrega = lblFecha.Text;

                    FacturaDeLaCompra ft = new FacturaDeLaCompra();
                    ft.CrearFacturaPDF();

                    DBAddOrders obj = new DBAddOrders();
                    obj.RealizarPedido(Usuario.Nombre + " " + Usuario.Apellidos, FacturaDeLaCompra.CodigoF, descripcion, FacturaDeLaCompra.FEntrega, FacturaDeLaCompra.total);

                    Mensaje msj = new Mensaje();

                    this.Hide();
                    msj.ShowDialog();
                    this.Close();
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Mensaje.mensaje = "CompraNoRealizada";
            this.Close();
        }

        private void lblFecha_MouseEnter(object sender, MouseEventArgs e)
        {
            lblFecha.Foreground = Brushes.Black;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int ptotal = 0;
            for (int i = 0; i < TotalPedidos.Cantidad.Count; i++)
            {
                ptotal += TotalPedidos.Cantidad[i];
            }
            if (ptotal > 0 && ptotal <= 3)
            {
                lblFecha.BlackoutDates.AddDatesInPast();
                lblFecha.BlackoutDates.Add(new CalendarDateRange(DateTime.Now, DateTime.Now.AddDays(1)));
            }
            if (ptotal > 3 && ptotal <= 10)
            {
                lblFecha.BlackoutDates.AddDatesInPast();
                lblFecha.BlackoutDates.Add(new CalendarDateRange(DateTime.Now, DateTime.Now.AddDays(2)));
            }
            else if (ptotal > 10 && ptotal <= 20)
            {
                lblFecha.BlackoutDates.AddDatesInPast();
                lblFecha.BlackoutDates.Add(new CalendarDateRange(DateTime.Now, DateTime.Now.AddDays(4)));
            }
            else if (ptotal > 20)
            {
                lblFecha.BlackoutDates.AddDatesInPast();
                lblFecha.BlackoutDates.Add(new CalendarDateRange(DateTime.Now, DateTime.Now.AddDays(8)));
            }
        }
    }
}
