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

namespace Visi0n._0.Pages.Company
{
    /// <summary>
    /// Interaction logic for CompanyDetailsPage.xaml
    /// </summary>
    public partial class CompanyDetailsPage : Page
    {
        User _user;
        Frame _frame;
        Corp _corporation;

        public CompanyDetailsPage(Frame frame, User u)
        {
            InitializeComponent();
            _frame = frame;
            _user = u;

            DataSetUp(_user);
        }

        private void DataSetUp(User u)
        {
            _corporation = UserService.Corporative(u);
            DetailsText.Content = "Company: \n\n";

            if (_corporation != null)
            {
                DetailsText.Content += "Name:  " + _corporation._cName + "\n";
                DetailsText.Content += "Corp ID:  " + _corporation._cid + "\n";
                DetailsText.Content += "Username:  " + _corporation._usrName + "\n";
                DetailsText.Content += "Password:  " + _corporation._pwd + "\n";
                DetailsText.Content += "Type:  " + _corporation._type + "\n";
                DetailsText.Content += "User ID:  " + _corporation._absId + "\n";
            }
            DetailsText.Content +=  "\nUser: \n\n";

            DetailsText.Content += "Username:  " + u._usrName + "\n";
            DetailsText.Content += "Password:  " + u._pwd + "\n";
            DetailsText.Content += "Type:  " + u._type + "\n";
            DetailsText.Content += "User ID:  " + u._absId + "\n";

            if (_corporation != null)
            {
                UsersText.Content = "Company users: \n";
                List<Person> ll = UserService.LaCampanella(_corporation);
                foreach (Person p in ll)
                {
                    UsersText.Content += ("" + p._absId + ", " + p._fName + " " + p._lName + "; ");
                }
            }
        }
    }
}
