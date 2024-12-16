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

namespace Visi0n._0
{
    /// <summary>
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class CompanyW : Window
    {
        public CompanyW()
        {
            InitializeComponent();

            Screen.Navigate(new CompanyDetailsPage(Screen));
            currentStateLabel.Content = "Current: Details";
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            DragMove();
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
            Screen.Navigate(new CalendarGP(Screen));
            currentStateLabel.Content = "Current: Calendar";
        }

        private void NotesB_Click(object sender, RoutedEventArgs e)
        {
            Screen.Navigate(new NotesGP(Screen));
            currentStateLabel.Content = "Current: Notes";
        }

        private void RemindersB_Click(object sender, RoutedEventArgs e)
        {
            Screen.Navigate(new RemindersGP(Screen));
            currentStateLabel.Content = "Current: Reminders";
        }

        private void CompanyDetailsB_Click(object sender, RoutedEventArgs e)
        {
            Screen.Navigate(new CompanyDetailsPage(Screen));
            currentStateLabel.Content = "Current: Details";
        }
    }
}
