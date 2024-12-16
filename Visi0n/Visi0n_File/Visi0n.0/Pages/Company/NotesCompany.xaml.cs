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
using Visi0n._0.Pages.Pesonal;

namespace Visi0n._0.Pages.Company
{
    /// <summary>
    /// Interaction logic for NotesCompany.xaml
    /// </summary>
    public partial class NotesCompany : Page
    {

        Frame _frame;

        public NotesCompany(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new NotesViewP(_frame));
        }
    }
}
