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
    /// Interaction logic for TypeUserCreatePage.xaml
    /// </summary>
    public partial class TypeUserCreatePage : Page
    {
        User _user;
        int _type;
        Window _win;

        string _cid;
        string _cName;
        string _fName;
        string _lName;

        public TypeUserCreatePage(User user, int type, Window wind)
        {
            InitializeComponent();

            _user = user;
            _win = wind;

            if (type == 1) { _type = 1; PersonG.Visibility = Visibility.Visible; CorpG.Visibility = Visibility.Collapsed; }
            else if (type == 2) { _type = 2; PersonG.Visibility = Visibility.Collapsed; CorpG.Visibility = Visibility.Visible; }
        }

        private void SetUp()
        {
            if (_type == 1) 
            {
                _fName = FNameT.Text;
                _lName = LNameT.Text;
                _cid = CorpT.Text;
                if (CorpT.Text == "Cid (--)") _cid = "--";
                UserService.CreatePerson(_user, _fName, _lName, _cid);
                MessageBox.Show("Attemped (P): " + _user._absId + ", " + _fName + ", " + _lName + ", " + _cid);
            }
            else if (_type == 2)
            {
                _cName = CNameT.Text;
                _cid = CIDT.Text;
                UserService.CreateCorp(_user, _cid, _cName);
                MessageBox.Show("Attemped (C): " + _user._absId + ", " + _cName + ", " + _cid);
            }
            new LoginW().Show();
            this._win.Close();
        }

        private void TextBoxClear(object sender, MouseButtonEventArgs e)
        {
            ((TextBox)sender).Text = string.Empty;
        }

        private void CreatePersonB_Click(object sender, RoutedEventArgs e)
        {
            SetUp();
        }

        private void CreateCorpB_Click(object sender, RoutedEventArgs e)
        {
            SetUp();
        }
    }
}
