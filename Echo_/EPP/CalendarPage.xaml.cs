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

namespace Visi0n._0.Pages.Pesonal
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        Frame _frame;

        public CalendarPage(Frame frame)
        {
            InitializeComponent();
            _frame = frame;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    //CaleGrid
                }
            }
            for (int i = 0; i < 4; i++)
            {
                //Label lb = new Label();
                

                //CaleGrid.Children.Add(lb);
            }

        }

        private void OpenDayAction(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new CalendarDayViewP(_frame, ((Label)sender).Content.ToString(), DateLabel.Content.ToString()));
        }
    }
}
