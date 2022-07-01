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
using System.Windows.Navigation;
using System.Windows.Threading;
using PequeñoSistema.Cards;
using PequeñoSistema.Clases;
using System.Threading;
using PequeñoSistema.Mensajes;

namespace PequeñoSistema
{
    /// <summary>
    /// Lógica de interacción para WindowPrincipal.xaml
    /// </summary>
    public partial class WindowPrincipal : Window
    {
        public static string ColorIcono;

        public WindowPrincipal()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void bMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void bExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ActivarColor()
        {
            try
            {
                if (ColorIcono == "Perfil")
                {
                    bPersona.Background = Brushes.LightGray;
                    bAdd.Background = Brushes.White;
                    bTienda.Background = Brushes.White;
                    bPedidos.Background = Brushes.White;
                    bList.Background = Brushes.White;
                    bHelp.Background = Brushes.White;
                }
                else if (ColorIcono == "AddProducts")
                {
                    bPersona.Background = Brushes.White;
                    bAdd.Background = Brushes.LightGray;
                    bTienda.Background = Brushes.White;
                    bPedidos.Background = Brushes.White;
                    bList.Background = Brushes.White;
                    bHelp.Background = Brushes.White;
                }
                else if (ColorIcono == "Productos")
                {
                    bPersona.Background = Brushes.White;
                    bAdd.Background = Brushes.White;
                    bTienda.Background = Brushes.LightGray;
                    bPedidos.Background = Brushes.White;
                    bList.Background = Brushes.White;
                    bHelp.Background = Brushes.White;
                }
                else if (ColorIcono == "Trolley")
                {
                    bPersona.Background = Brushes.White;
                    bAdd.Background = Brushes.White;
                    bTienda.Background = Brushes.White;
                    bPedidos.Background = Brushes.LightGray;
                    bList.Background = Brushes.White;
                    bHelp.Background = Brushes.White;
                }
                else if (ColorIcono == "bList")
                {
                    bPersona.Background = Brushes.White;
                    bAdd.Background = Brushes.White;
                    bTienda.Background = Brushes.White;
                    bPedidos.Background = Brushes.White;
                    bList.Background = Brushes.LightGray;
                    bHelp.Background = Brushes.White;
                }
                else if (ColorIcono == "bHelp")
                {
                    bPersona.Background = Brushes.White;
                    bAdd.Background = Brushes.White;
                    bTienda.Background = Brushes.White;
                    bPedidos.Background = Brushes.White;
                    bList.Background = Brushes.White;
                    bHelp.Background = Brushes.LightGray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                framePrin.NavigationService.Navigate(new PageCards());

                ColorIcono = "Productos";
                this.ActivarColor();
                this.LimpiarLista();
              
                //bAdd.Visibility = Visibility.Visible;
                if (Usuario.Administrador.Trim() == "yes")
                {
                    bAdd.Visibility = Visibility.Visible;
                }
                else
                {
                    bAdd.Visibility = Visibility.Collapsed;
                }

                PantallaEspera espera = new PantallaEspera();
                espera.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bPerson_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                framePrin.NavigationService.Navigate(new PageUser());
                ColorIcono = "Perfil";
                this.ActivarColor();
                this.LimpiarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                framePrin.NavigationService.Navigate(new PageAddProducts());
                ColorIcono = "AddProducts";
                this.ActivarColor();
                this.LimpiarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bTienda_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                framePrin.NavigationService.Navigate(new PageCards());
                ColorIcono = "Productos";
                this.ActivarColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void bPedidos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                framePrin.NavigationService.Navigate(new PageTrolley());
                ColorIcono = "Trolley";
                this.ActivarColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                framePrin.NavigationService.Navigate(new PageOrderList());
                ColorIcono = "bList";
                this.ActivarColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bHelp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                framePrin.NavigationService.Navigate(new PageHelp());
                ColorIcono = "bHelp";
                this.ActivarColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarLista()
        {
            if (ColorIcono != "Productos")
            {
                TotalProductos.ListID.Clear();
                TotalProductos.ListNombre.Clear();
                TotalProductos.ListTamaño.Clear();
                TotalProductos.ListPrecio.Clear();
                TotalProductos.ListImagen.Clear();
                TotalProductos.ListIngredientes.Clear();
            }
        }

        private void btnExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow ins = new MainWindow();

            this.Hide();
            ins.ShowDialog();
            this.Close();
        }
    }
}
