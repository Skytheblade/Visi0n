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
using Visi0n._0.Pages;
using Visi0n._0.Pages.Pesonal;
using Visi0n._0.Pages.General;
using System.Windows.Controls.Primitives;
using Model_;

namespace Visi0n._0
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PersonalW : Window
    {
        User _user;

        public PersonalW(User usr = null)
        {
            InitializeComponent();
            Section("f");
            Frame01.Navigate(new PersonalHome());
            if (usr != null) UserSetUp(usr);
        }

        private void UserSetUp(User u)
        {
            _user = u;

            usrName.Content = _user._usrName;
            usrPass.Content = _user._pwd;
            usrType.Content = _user._type;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { } // if cant drag, then don't
        }


        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            new LoginW().Show();
            this.Close();
        }



        private void Frame01_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //ToFrame();
        }

        private void HomeP_Click(object sender, RoutedEventArgs e)
        {
            Section("f");
            Frame01.Navigate(new PersonalHome(_user));
            CurrentPage.Content = "Home";
            HomeP.IsChecked = false;

            /*MessageBox.Show("Ideas to make this unique and better: \n" +
                "Create gaming (skyblock) profile page \n" +
                "Create sprort and sw page \n" +
                "Make corporate chat \n" +
                "");*/
        }
        private void CalP_Click(object sender, RoutedEventArgs e)
        {
            Section("f");
            Frame01.Navigate(new CalendarGP(Frame01, _user));
            CurrentPage.Content = "Calendar";
            CalP.IsChecked = false;
        }
        private void NoteP_Click(object sender, RoutedEventArgs e)
        {
            Section("f");
            Frame01.Navigate(new NotesGP(Frame01, null, _user));
            CurrentPage.Content = "Notes";
            NoteP.IsChecked = false;
        }
        private void RemindP_Click(object sender, RoutedEventArgs e)
        {
            Section("f");
            Frame01.Navigate(new RemindersGP(Frame01, _user));
            CurrentPage.Content = "Reminders";
            RemindP.IsChecked = false;
        }


        private void minmax_Checked(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;

            minmax.IsChecked = false;
        }
        private void fold_Checked(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            fold.IsChecked = false;
        }

        private void pfpC(object sender, MouseButtonEventArgs e)
        {
            Section("a");
        }

        private void Section(string type__)
        {
            if (type__ == "a")
            {
                Frame01.Visibility = Visibility.Collapsed;
                AccSec.Visibility = Visibility.Visible;
                SettSec.Visibility = Visibility.Collapsed;
            }
            if (type__ == "s")
            {
                Frame01.Visibility = Visibility.Collapsed;
                AccSec.Visibility = Visibility.Collapsed;
                SettSec.Visibility = Visibility.Visible;
            }
            if (type__ == "f")
            {
                Frame01.Visibility = Visibility.Visible;
                AccSec.Visibility = Visibility.Collapsed;
                SettSec.Visibility = Visibility.Collapsed;
            }
        }

        private void Settings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Section("s");
        }

        private void darkLightMode_Click(object sender, RoutedEventArgs e)
        {
            if (togglelabel.Content == "dark (not coming soon)")
            {
                togglelabel.Content = "light";
                darkLightMode.IsChecked = false;
            }
            else
            {
                togglelabel.Content = "dark (not coming soon)";
                darkLightMode.IsChecked = false;
            }
        }
    }
}
