using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Visi0n._0.Model;

namespace Visi0n._0.VModel
{
    class UserService01
    {
        public static bool LoginAtt(string usrname, string pass)
        {
            _UserDB usrdb = new _UserDB();
            User usr = usrdb.CreateUser();

            if (usr._usrName == usrname && usr._pwd == pass) return true;
            return false;
        }
    }
}
