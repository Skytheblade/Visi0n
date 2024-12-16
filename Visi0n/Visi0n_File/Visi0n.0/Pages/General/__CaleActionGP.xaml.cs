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
    /// Interaction logic for __CaleActionGP.xaml
    /// </summary>
    public partial class __CaleActionGP : Page
    {
        Frame _frame;
        string _date;
        ListViewItem _target = null;

        public __CaleActionGP(Frame frame, string date)
        {
            InitializeComponent();

            _frame = frame;
            _date = date;
        }

        private void Save()
        {
            _target = new ListViewItem();
            _target.Content = AcName.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Save();
            _frame.Navigate(new _CaleDayViewGP(_frame, _date, _target));
        }
    }
}
