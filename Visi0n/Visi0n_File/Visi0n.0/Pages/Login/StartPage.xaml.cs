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

namespace Visi0n._0.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        Frame target;
        Window _win;

        public StartPage(Frame frame, Window win)
        {
            InitializeComponent();
            this.target = frame;
            this._win = win;
        }

        private void SetLoginP(object sender, RoutedEventArgs e)
        {
            target.Navigate(new LoginPage(target, _win, 1));
        }
        private void SetLoginC(object sender, RoutedEventArgs e)
        {
            target.Navigate(new LoginPage(target, _win, 2));
        }
    }
}
