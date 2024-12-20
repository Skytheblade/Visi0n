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
    /// Interaction logic for NotesGP.xaml
    /// </summary>
    public partial class NotesGP : Page
    {
        Frame _frame;
        NoteItem _note;
        int posCur;

        public NotesGP(Frame frame, NoteItem nt = null)
        {
            InitializeComponent();
            _frame = frame;
            _note = nt;

            posCur = 3;
            if (nt != null) { AddItem(nt, posCur); }
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new _NotesViewGP(_frame));
        }

        private void AddItem(NoteItem nt, int pos)
        {
            Label label = new Label() { Content = nt._name, Margin = new Thickness(5, 5, 5, 5) };
            label.Style = (Style)FindResource("Note01");
            Grid.SetRow(label, pos);
            Table.Children.Add(label);
            posCur++;
        }
    }
}
