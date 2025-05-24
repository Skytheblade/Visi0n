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
using Visi0n._0.Pages.General;

namespace Visi0n._0.Pages.Company
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class CompanyPersonalPage : Page
    {
        User _user;

        public CompanyPersonalPage(User u)
        {
            InitializeComponent();

            _user = u;

            controlPanel.Children.Add(new Menu001(OverruleF, _user, 1));
            controlPanel.Children.Add(new Menu001(OverruleF, _user, 2));
            controlPanel.Children.Add(new Menu001(OverruleF, _user));
        }


        private void CaleB(object sender, RoutedEventArgs e)
        {
            OverruleF.Navigate(new CalendarGP(OverruleF, _user));
        }

        private void NotesB(object sender, RoutedEventArgs e)
        {
            OverruleF.Navigate(new NotesGP(OverruleF, _user));
        }

        private void RemB(object sender, RoutedEventArgs e)
        {
            OverruleF.Navigate(new RemindersGP(OverruleF, _user));
        }
    }
}
