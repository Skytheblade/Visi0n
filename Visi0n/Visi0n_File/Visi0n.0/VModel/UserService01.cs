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
        public static bool LoginAtt(string usrname, string pass, int id = 2)
        {
            _UserDB usrdb = new _UserDB();
            User usr = usrdb.TargetSelect(id);

            if (usr._usrName == usrname && usr._pwd == pass) return true;
            return false;
            //return true;
        }

        public static User Get(int id = 2)
        {
            _UserDB usrdb = new _UserDB();
            User usr = usrdb.TargetSelect(id);
            if (usr._absId == id) return usr;
            else return null;
            //return new User("Name0", "Pass0", id);
        }
    }
}
