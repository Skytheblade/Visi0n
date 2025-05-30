﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    /// <summary>
    /// The target of contact, the actual user, in its basic state
    /// </summary>
    public class User : Entity
    {
        public int _absId;
        public string _usrName { get; set; }
        public string _pwd { get; set; }
        public int _type;

        public User()
        {
            _usrName = "";
            _pwd = "";
            _absId = -1;
            _type = 0;
        }

        public User(string un, string pd, int id, int t)
        {
            _usrName = un;
            _pwd = pd;
            _absId = id;
            _type = t;
        }

        public virtual void Copy(User u)
        {
            _usrName = u._usrName;
            _pwd = u._pwd;
            _absId = u._absId;
            _type = u._type;
        }
    }
}
