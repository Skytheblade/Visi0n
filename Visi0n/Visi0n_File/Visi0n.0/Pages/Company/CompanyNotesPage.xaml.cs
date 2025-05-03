using Model_;
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

namespace Visi0n._0.Pages.Company
{
    /// <summary>
    /// Interaction logic for CompanyNotesPage.xaml
    /// </summary>
    public partial class CompanyNotesPage : Page
    {
        Corp _self;
        User _user;

        public CompanyNotesPage(User u)
        {
            InitializeComponent();

            _user = u;
            _self = UserService.Corporative(_user); //assuming validity
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendNote();
        }

        // one for all will be probably added in the future
        private void SendNote()
        {
            bool f = true;
            try
            {
                int id = int.Parse(Uid.Text);
            }
            catch { f = false; }
            if (f)
            {
                List<Person> emp = UserService.LaCampanella(_self);
                User u0 = UserService.Get(int.Parse(Uid.Text));
                User uu = null;
                foreach (User u in emp)
                {
                    if (u._absId == u0._absId) uu = u0;
                }

                if (uu != null) { MessageBox.Show($"Attempting Note for id: {uu._absId}"); NoteService.ScrapWrite(Nname.Text, Ntext.Text, uu._absId, _self._cid); }
                else MessageBox.Show("Make sure Uid is registered in the company");
            }
            else MessageBox.Show("Make sure input matches target types");
        }
    }
}
