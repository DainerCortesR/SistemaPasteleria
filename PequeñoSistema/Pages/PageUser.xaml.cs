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
using PequeñoSistema.Clases;
using PequeñoSistema.DB;
using PequeñoSistema.Mensajes;

namespace PequeñoSistema.Pages
{
    /// <summary>
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        public PageUser()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtName.Text = Usuario.Nombre;
                txtSurname.Text = Usuario.Apellidos;
                txtUser.Text = Usuario.UsuarioN;
                txtCorreo.Text = Usuario.Correo;
                txtPassword.Password = Usuario.Contraseña;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Guardar()
        {
            try
            {
                DBUpdateUser upd = new DBUpdateUser();

                if (txtName.Text.Trim() == "")
                {
                    txtName.Foreground = Brushes.Red;
                }
                if (txtSurname.Text.Trim() == "")
                {
                    txtSurname.Foreground = Brushes.Red;
                }
                if (txtUser.Text.Trim() == "")
                {
                    txtUser.Foreground = Brushes.Red;
                }
                if (txtCorreo.Text.Trim() == "")
                {
                    txtCorreo.Foreground = Brushes.Red;
                }
                if (txtPassword.Password.Trim() == "")
                {
                    txtPassword.Foreground = Brushes.Red;
                }
                if (txtPasswordConfirm.Password != txtPassword.Password)
                {
                    txtPasswordConfirm.Foreground = Brushes.Red;
                }
                else if (txtName.Text.Trim() != "" && txtSurname.Text.Trim() != "" && txtUser.Text.Trim() != "" && txtCorreo.Text.Trim() != "" &&
                    txtPassword.Password.Trim() != "" && txtPasswordConfirm.Password == txtPassword.Password)
                {
                    upd.ActulizarDatos(txtUser.Text, txtName.Text, txtSurname.Text, txtCorreo.Text, txtPassword.Password);

                    Mensaje.Msg1 = "Operación realizada con éxito";
                    Mensaje.Msg2 = "Sus datos fueron actualizados";
                    Mensaje.mensaje = "";

                    Mensaje msg = new Mensaje();

                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
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
        }

        private void txtPasswordConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            txtPasswordConfirm.Foreground = Brushes.Black;

            if (e.Key == Key.Return)
            {
                Guardar();
            }
        }
    }
}
