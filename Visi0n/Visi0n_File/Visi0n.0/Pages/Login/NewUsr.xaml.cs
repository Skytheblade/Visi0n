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
using VModel_;
using Model_;

namespace Visi0n._0.Pages
{
    /// <summary>
    /// Interaction logic for NewUsr.xaml
    /// </summary>
    public partial class NewUsr : Page
    {
        Frame _frame;
        Window _win;
        int _type;

        public NewUsr(Frame frame, Window win, int type)
        {
            InitializeComponent();
            _frame = frame;
            _win = win;
            _type = type;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new LoginPage(_frame, _win, _type));
        }

        private void TextBoxClear(object sender, MouseButtonEventArgs e)
        {
            ((TextBox)sender).Text = string.Empty;
        }

        private void usrCreate_Click(object sender, RoutedEventArgs e)
        {
            User uu = UserService.MakeUser(usrnameBox.Text, usrpassBox.Text, _type);
            MessageBox.Show("attempted creation for: " +
                usrnameBox.Text + ", " + usrpassBox.Text + ", " + _type + " with next id");
            _frame.Navigate(new TypeUserCreatePage(uu, _type, _win));
        }
    }
}
