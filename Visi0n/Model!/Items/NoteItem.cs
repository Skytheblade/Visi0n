using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class NoteItem : Entity
    {
        public int _uid;
        public string _name;
        public string _text;
        public string _cid;

        public NoteItem()
        {
            _name = "";
            _text = "";
            _uid = -1;
            _cid = "--";
        }

        public NoteItem(string n, string t, int u, string c = "--")
        {
            _name = n;
            _text = t;
            _uid = u;
            _cid = c;
        }
    }
}
