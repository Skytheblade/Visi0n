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
using Visi0n._0.Pages;

namespace Visi0n._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginW : Window
    {
        public LoginW()
        {
            InitializeComponent();
            FrameL.Navigate(new StartPage(FrameL, this));
            MessageBox.Show("Click the i button for info and instructions");
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            DragMove();
        }

        private void Mini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maxi_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            new InfoW().Show();
        }
    }
}
