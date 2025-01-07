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
using Visi0n._0.VModel;

namespace Visi0n._0.Pages.General
{
    /// <summary>
    /// Interaction logic for _NotesViewGP.xaml
    /// </summary>
    public partial class _NotesViewGP : Page
    {
        Frame _frame;
        NoteItem _item;

        public _NotesViewGP(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new NotesGP(_frame, new NoteItem(Name.Text, Text.Text, -1)));
        }
    }
}
