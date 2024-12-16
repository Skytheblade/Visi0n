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

namespace Visi0n._0
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PersonalW : Window
    {
        public PersonalW()
        {
            InitializeComponent();
            Frame01.Navigate(new PersonalHome());
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            DragMove();
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

        private void HomeP_Click(object sender, RoutedEventArgs e)
        {
            Frame01.Navigate(new PersonalHome());
            CurrentPage.Content = "Home";
        }

        private void Frame01_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void CalP_Click(object sender, RoutedEventArgs e)
        {
            Frame01.Navigate(new CalendarGP(Frame01));
            CurrentPage.Content = "Calendar";
        }

        private void NoteP_Click(object sender, RoutedEventArgs e)
        {
            Frame01.Navigate(new NotesGP(Frame01));
            CurrentPage.Content = "Notes";
        }

        private void RemindP_Click(object sender, RoutedEventArgs e)
        {
            Frame01.Navigate(new RemindersGP(Frame01));
            CurrentPage.Content = "Reminders";
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
    }
}
