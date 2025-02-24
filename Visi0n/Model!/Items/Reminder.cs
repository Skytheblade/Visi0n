using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class Reminder : Entity
    {
        public int _uid;
        public string _text;

        public Reminder()
        {
            _uid = -1;
            _text = "";
        }

        public Reminder(int u, string t)
        {
            _uid = u;
            _text = t;
        }
    }
}
