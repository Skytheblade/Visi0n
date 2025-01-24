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

namespace Visi0n._0
{
    /// <summary>
    /// Interaction logic for InfoW.xaml
    /// </summary>
    public partial class InfoW : Window
    {
        public InfoW()
        {
            InitializeComponent();
            Information.Content = "Version: 0.2;\nProgress to basic completion: 85%, all screens ready, raw, logic incomplete;\nOverall progress: 30%\n \nInstructions:\n" +
                "Login textboxes - click to select, new text will appear on start. double click to clear.\n" +
                "Username, Password (as prewritten) to log in as a test subject. \n" +
                "Personal: click on the sea image (future pfp) to load account page, there is a logout button. Same for setting page (icon), currently empty. Home page is also currently empty. \n" +
                "Notes Page - click note for edit or removal (logic for both will be finished later with the completion of database logic), double click + to add. \n" +
                "Callendar - click date to select, double click to view. then event click to select. \n" +
                "Reminders - removal will be added later on. \n";
        }
    }
}
