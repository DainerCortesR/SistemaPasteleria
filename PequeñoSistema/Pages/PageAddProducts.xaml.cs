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
using PequeñoSistema.DB;

namespace PequeñoSistema.Pages
{
    /// <summary>
    /// Lógica de interacción para PageAddProducts.xaml
    /// </summary>
    public partial class PageAddProducts : Page
    {
        public PageAddProducts()
        {
            InitializeComponent();
        }
         
        private void Añadir()
        {
            try
            {
                if (txtName.Text == "")
                {
                    txtName.Foreground = Brushes.Red;
                }
                if (txtSize.Text == "")
                {
                    txtSize.Foreground = Brushes.Red;
                }
                if (txtCost.Text == "")
                {
                    txtCost.Foreground = Brushes.Red;
                }
                if (txtPicture.Text == "")
                {
                    txtPicture.Foreground = Brushes.Red;
                }
                if (txtIngredients.Text == "")
                {
                    txtIngredients.Foreground = Brushes.Red;
                }
                if (imgContent.Source == null)
                {
                    txtPicture.Foreground = Brushes.Red;
                }
                if (txtName.Text != "" && txtSize.Text != "" && txtCost.Text != "" && txtPicture.Text != "" && txtIngredients.Text != "" && imgContent.Source != null)
                {
                    DBAddProducts dbAdd = new DBAddProducts();

                    dbAdd.AddProduct(txtName.Text, txtSize.Text, txtCost.Text, txtPicture.Text, txtIngredients.Text);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Añadir();   
        }

        private void LimpiarCampos()
        {
            txtName.Clear();
            txtSize.Clear();
            txtCost.Clear();
            txtPicture.Clear();
            txtIngredients.Clear();
            imgContent.Source = null;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            txtName.Foreground = Brushes.Black;
        }

        private void txtSize_KeyDown(object sender, KeyEventArgs e)
        {
            txtSize.Foreground = Brushes.Black;
        }

        private void txtCost_KeyDown(object sender, KeyEventArgs e)
        {
            txtCost.Foreground = Brushes.Black;
        }

        private void txtPicture_KeyDown(object sender, KeyEventArgs e)
        {
            txtPicture.Foreground = Brushes.Black;
        }

        private void txtIngredients_KeyDown(object sender, KeyEventArgs e)
        {
            txtIngredients.Foreground = Brushes.Black;

            if (e.Key == Key.Return)
            {
                Añadir();
            }
        }
    }
}
