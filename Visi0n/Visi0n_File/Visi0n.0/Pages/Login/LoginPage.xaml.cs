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
using Model_;
using VModel_;

namespace Visi0n._0.Pages
{
    /// <summary>
    /// Interaction logic for PLoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Window _win;
        Frame _frame;
        int _type;

        public LoginPage(Frame frame, Window win, int tp)
        {
            InitializeComponent();
            _win = win;
            _frame = frame;
            _type = tp;
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(usrnameBox.Text + "  " + usrpassBox.Text);

            if (UserService.LoginAtt(usrnameBox.Text, usrpassBox.Text, _type))
            {
                int idd = new UserDB().FindID(usrnameBox.Text);
                if (_type == 1) new PersonalW(UserService.Get(idd)).Show();
                else new CompanyW(UserService.Get(idd)).Show();
                _win.Close();
            }
            else
            {
                MessageBox.Show("Login info incorrect");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new StartPage(_frame, _win));
        }

        private void usrNew_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new NewUsr(_frame, _win, _type));
        }

        private void TextBoxClear(object sender, MouseButtonEventArgs e)
        {
            ((TextBox)sender).Text = string.Empty;
        }
    }
}
