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
using System.Windows.Shapes;
using Visi0n._0.Pages.Company;
using Visi0n._0.Pages.General;
using Visi0n._0.Pages.Pesonal;
using Model_;
using VModel_;

namespace Visi0n._0
{
    /// <summary>
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class CompanyW : Window
    {
        User _user;

        public CompanyW(User usr = null)
        {
            InitializeComponent();

            if (usr != null) UserSetUp(usr);

            Screen.Navigate(new CompanyDetailsPage(Screen, _user));
            currentStateLabel.Content = "Current: Details";
        }
        private void UserSetUp(User u)
        {
            _user = u;
            Corp c = UserService.Corporative(u);
            if (c != null) CompanyNameLabel.Content = c._cName + " (" + c._cid + ")";
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            try { DragMove(); }
            catch { }
        }



        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            new LoginW().Show();
            this.Close();
        }

        private void CalendarB_Click(object sender, RoutedEventArgs e)
        {
            Screen.Navigate(new CalendarGP(Screen, _user));
            currentStateLabel.Content = "Current: Calendar";
        }

        private void NotesB_Click(object sender, RoutedEventArgs e)
        {
            Screen.Navigate(new NotesGP(Screen, _user));
            currentStateLabel.Content = "Current: Notes";
        }

        private void RemindersB_Click(object sender, RoutedEventArgs e)
        {
            Screen.Navigate(new RemindersGP(Screen, _user));
            currentStateLabel.Content = "Current: Reminders";
        }

        private void CompanyDetailsB_Click(object sender, RoutedEventArgs e)
        {
            Screen.Navigate(new CompanyDetailsPage(Screen, _user));
            currentStateLabel.Content = "Current: Details";
        }
    }
}
