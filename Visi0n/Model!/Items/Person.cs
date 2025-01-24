using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public  class Person : User
    {
        public string _fName;
        public string _lName;
        public string _cid;

        public Person() : base() { _fName = ""; _lName = ""; _cid = "-"; }

        public Person(string cid, string fName, string lName, string un, string pd, int id) : base(un, pd, id, 1)
        {
            _cid = cid;
            _fName = fName;
            _lName = lName;
        }
    }
}
