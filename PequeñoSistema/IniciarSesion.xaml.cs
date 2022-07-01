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
using MaterialDesignThemes;
using MaterialDesignColors;
using PequeñoSistema.DB;
using MaterialDesignThemes.Wpf;
using PequeñoSistema.Mensajes;
using System.IO;

namespace PequeñoSistema
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Usuario { get; set; }
        private string Contraseña { get; set; }
 
        public MainWindow()
        {
            this.Usuario = "administrador";
            this.Contraseña = "dragon123";

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

        private void IniciarSistema()
        {
            try
            {
                DBLogin log = new DBLogin();

                if (log.Login(txtUsername.Text, txtPassword.Password) == true)
                {
                    WindowPrincipal wp = new WindowPrincipal();
                    this.Hide();
                    wp.ShowDialog();
                    this.Close();
                }
                else
                {
                    txtUsername.Foreground = Brushes.Red;
                    txtPassword.Foreground = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            IniciarSistema();
        }

        private void btnCrearCuenta_Click(object sender, RoutedEventArgs e)
        {
            CrearCuenta wp = new CrearCuenta();
            this.Hide();
            wp.ShowDialog();
            this.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            txtUsername.Foreground = Brushes.Black;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            txtPassword.Foreground = Brushes.Black;

            if (e.Key == Key.Return)
            {
                IniciarSistema();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string folderPath = @"C:\CachePasteleria";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            DirectoryInfo di = new DirectoryInfo(folderPath);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
        }
    }
}
