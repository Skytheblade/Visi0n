using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visi0n._0.VModel
{
    public class User
    {
        public string _usrName { get; set; }
        public string _pwd { get; set; }

        public User() 
        {
            _usrName = "";
            _pwd = "";
        }

        public User(string un, string pd) 
        {
            _usrName = un;
            _pwd = pd;
        }
    }
}
