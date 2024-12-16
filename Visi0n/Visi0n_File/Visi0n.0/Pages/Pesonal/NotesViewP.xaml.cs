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
    /// Interaction logic for NotesViewP.xaml
    /// </summary>
    public partial class NotesViewP : Page
    {

        Frame _frame;

        public NotesViewP(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new NotesPage(_frame));
        }
    }
}
