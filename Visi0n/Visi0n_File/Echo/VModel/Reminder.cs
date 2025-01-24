using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visi0n._0.VModel
{
    public class Reminder
    {
        public int _uid;
        public string _text;

        public Reminder()
        { 
            _uid = 0;
            _text = "";
        }

        public Reminder(int u, string t)
        { 
            _uid = u;
            _text = t;
        }
    }
}
