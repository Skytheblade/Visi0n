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

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for RemindersGP.xaml
    /// </summary>
    public partial class RemindersGP : Page
    {
        Frame _frame;
        int posCur;

        public RemindersGP(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            posCur = 7;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckBox ck = new CheckBox() { Content = TextName.Text, Margin = new Thickness(4, 4, 4, 4) };
            ck.Style = (Style)FindResource("Reminder01");
            Grid.SetRow(ck, posCur);
            posCur++;
            Rtable.Children.Add(ck);
        }
    }
}
