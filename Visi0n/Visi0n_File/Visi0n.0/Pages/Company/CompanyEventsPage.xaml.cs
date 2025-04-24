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
    /// Interaction logic for CompanyEventsPage.xaml
    /// </summary>
    public partial class CompanyEventsPage : Page
    {
        User _user;
        Corp _self;

        public CompanyEventsPage(User u)
        {
            InitializeComponent();

            _user = u;
            _self = UserService.Corporative(_user); //assuming validity
        }

        private void SendEvent() 
        {
            bool f = true;
            try
            {
                int id = int.Parse(Uid.Text);
                int ddat = int.Parse(Tdd.Text + Tmm.Text + Tyy.Text);
            }
            catch { f = false; }
            if (f && Tdd.Text.Length == 2 && Tmm.Text.Length == 2 && Tyy.Text.Length == 4 && int.Parse(Tdd.Text) < 32 && int.Parse(Tmm.Text) < 13)
            {
                List<Person> emp = UserService.LaCampanella(_self);
                User u0 = UserService.Get(int.Parse(Uid.Text));
                User uu = null;
                foreach (User u in emp)
                {
                    if (u._absId == u0._absId) uu = u0;
                }

                if (uu != null) { MessageBox.Show($"Attempting Event for id: {uu._absId}"); EventService.WriteEclipse(uu, null, Ename.Text, Etext.Text, "" + Tdd.Text + "/" + Tmm.Text + "/" + Tyy.Text, _self._cid); }
                else MessageBox.Show("Make sure Uid is registered in the company");
            }
            else MessageBox.Show("Make sure input matches target types");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendEvent();
        }
    }
}
