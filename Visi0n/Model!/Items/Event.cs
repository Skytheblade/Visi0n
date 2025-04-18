using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class Event : Entity
    {
        public int _uid;
        public string _name;
        public string _description;
        public string _date;
        public int _ID;
        public string _cid;

        public Event(int u, string n, string d, string t, int i, string cc = "--")
        {
            _uid = u;
            _name = n;
            _description = d;
            _date = t;
            _ID = i;
            _cid = cc;
        }

        public Event()
        {
            _uid = -1;
            _name = string.Empty;
            _description = string.Empty;
            _date = string.Empty;
            _ID = -1;
            _cid = "--";
        }

        public Event Copy() => new Event(_uid, _name, _description, _date, _ID, _cid);
    }
}
