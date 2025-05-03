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
using System.Xml.Linq;
using VModel_;

namespace Visi0n._0.Pages.Company
{
    /// <summary>
    /// Interaction logic for CompanyRemindersPage.xaml
    /// </summary>
    public partial class CompanyRemindersPage : Page
    {
        Corp _self;

        public CompanyRemindersPage(User u)
        {
            InitializeComponent();

            _self = UserService.Corporative(u);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendReminder();
        }

        private void SendReminder()
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

                if (uu != null) { MessageBox.Show($"Attempting Note for id: {uu._absId}"); ReminderService.ListNewReminder(uu._absId, RText.Text, _self._cid); }
                else MessageBox.Show("Make sure Uid is registered in the company");
            }
            else MessageBox.Show("Make sure input matches target types");
        }
    }
}
