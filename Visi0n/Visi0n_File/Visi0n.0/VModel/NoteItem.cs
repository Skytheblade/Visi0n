using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visi0n._0.VModel
{
    public class NoteItem
    {
        public int _uid;
        public string _name;
        public string _text;

        public NoteItem(string n, string t, int u)
        {
            _name = n;
            _text = t;
            _uid = u;
        }
    }
}
