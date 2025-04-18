using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model_
{
    /// <summary>
    /// A continium of user for personal matters - all (person) are (user)
    /// </summary>
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

        public override void Copy(User u)
        {
            base.Copy(u);
            Person p; if (u is Person) p = u as Person; else p = new Person();
            _cid = p._cid;
            _fName = p._fName;
            _lName = p._lName;
        }
    }
}
