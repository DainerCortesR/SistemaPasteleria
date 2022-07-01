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

namespace PequeñoSistema
{
    /// <summary>
    /// Lógica de interacción para CrearCuenta.xaml
    /// </summary>
    public partial class CrearCuenta : Window
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private void bMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void IniciarSistema()
        {
            try
            {
                if (txtName.Text == "")
                {
                    txtName.Foreground = Brushes.Red;
                }
                if (txtSurname.Text == "")
                {
                    txtSurname.Foreground = Brushes.Red;
                }
                if (txtUser.Text == "")
                {
                    txtUser.Foreground = Brushes.Red;
                }
                if (txtCorreo.Text == "")
                {
                    txtCorreo.Foreground = Brushes.Red;
                }
                if (txtPassword.Password == "")
                {
                    txtPassword.Foreground = Brushes.Red;
                }
                if (txtName.Text != "" && txtSurname.Text != "" && txtUser.Text != "" && txtCorreo.Text != "" && txtPassword.Password != "")
                {
                    DBCreateAccount dca = new DBCreateAccount();

                    dca.CreateAccount(txtUser.Text, txtName.Text, txtSurname.Text, txtCorreo.Text, txtPassword.Password);

                    WindowPrincipal wdp = new WindowPrincipal();
                    this.Hide();
                    wdp.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrearCuenta_Click(object sender, RoutedEventArgs e)
        {
            IniciarSistema();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ins = new MainWindow();
            this.Hide();
            ins.ShowDialog();
            this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            txtName.Foreground = Brushes.Black;
        }

        private void txtSurname_KeyDown(object sender, KeyEventArgs e)
        {
            txtSurname.Foreground = Brushes.Black;
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            txtUser.Foreground = Brushes.Black;
        }

        private void txtCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            txtCorreo.Foreground = Brushes.Black;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            txtPassword.Foreground = Brushes.Black;

            if (e.Key == Key.Return)
            {
                IniciarSistema();
            }
        }
    }
}
