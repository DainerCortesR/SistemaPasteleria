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
using System.Diagnostics;

namespace PequeñoSistema.Pages
{
    /// <summary>
    /// Lógica de interacción para PageHelp.xaml
    /// </summary>
    public partial class PageHelp : Page
    {
        public PageHelp()
        {
            InitializeComponent();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BtnView1.Visibility == Visibility.Collapsed)
            {
                BtnView1.Visibility = Visibility.Visible;
            }
        }

        private void ImgTwitter_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BtnView2.Visibility == Visibility.Collapsed)
            {
                BtnView2.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseEnter_1(object sender, MouseEventArgs e)
        {
            if (BtnView3.Visibility == Visibility.Collapsed)
            {
                BtnView3.Visibility = Visibility.Visible;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BtnView1.Visibility = Visibility.Collapsed;
            BtnView2.Visibility = Visibility.Collapsed;
            BtnView3.Visibility = Visibility.Collapsed;
        }


        private void BtnView1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BtnView1.Visibility == Visibility.Visible)
            {
                BtnView1.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnView2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BtnView2.Visibility == Visibility.Visible)
            {
                BtnView2.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnView3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BtnView3.Visibility == Visibility.Visible)
            {
                BtnView3.Visibility = Visibility.Collapsed;
            }
        }

        private void btnGitHub_Click(object sender, RoutedEventArgs e)
        {
            OpenURL(1);
        }

        private void BtnView1_Click(object sender, RoutedEventArgs e)
        {
            OpenURL(1);
        }

        private void BtnView2_Click(object sender, RoutedEventArgs e)
        {
            OpenURL(2);
        }

        private void btnjk_Click(object sender, RoutedEventArgs e)
        {
            OpenURL(2);
        }

        private void BtnView3_Click(object sender, RoutedEventArgs e)
        {
            OpenURL(3);
        }

        private void btns_Click(object sender, RoutedEventArgs e)
        {
            OpenURL(3);
        }

        private void OpenURL(int valor)
        {
            if (valor == 1)
            {
                Process.Start("https://github.com/DainerCortesR");
            }
            else if (valor == 2)
            {
                Process.Start("https://twitter.com/dainer_cortes");
            }
            else if (valor == 3)
            {
                Process.Start("https://www.tiktok.com/@universof4");
            }
        }
    }
}
