using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model_;

namespace VModel_
{
    public class UserDB : BaseDB
    {
        //"SELECT * FROM Usr_Tbl"

        public UserDB() : base() { }


        protected override Entity EGen()
        {
            return new User();
        }

        public override Entity TargetSelect(int id, string cmdTxt = "SELECT *, Usr_Tbl.ID AS id FROM (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id)")
        {
            List<Entity> cl = base.Collect(cmdTxt);
            foreach (User u in cl)
            { if (u._absId == id) return u; }
            return new User();
        }

        public override void CreateModel(Entity e)
        {
            User u = (User)e;
            u._usrName = reader["UserName"].ToString();
            u._pwd = reader["PassCode"].ToString();
            u._absId = int.Parse(reader["ID"].ToString());
            u._type = int.Parse(reader["Type"].ToString());
        }


        public override List<Entity> SelectAll(string cmdTxt = "SELECT *, Usr_Tbl.ID AS id FROM (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id)")
        {
            return base.Collect(cmdTxt);
        }


        public override async Task<int> Insert(Entity e)
        {
            User usr;
            if (e is User) usr = e as User;
            else return -1;

            User uLast = (User)SelectAll().Last(); // not perfect
            int lid = uLast._absId + 1;

            int records = 0; // affected lines

            string sqlStr = string.Format("INSERT INTO Usr_Tbl (UserName, PassCode) "
                + "VALUES (?, ?);");
            //do not insert autonumber, and do not use 'Password' fields (syntax error)
            CommandSet(sqlStr);
            command.Parameters.AddWithValue("?", usr._usrName);
            command.Parameters.AddWithValue("?", usr._pwd);
            await Edit();

            sqlStr = $"INSERT INTO TypeUser_Tbl (ID, Type) "
                + $"VALUES ({lid}, {usr._type});";
            CommandSet(sqlStr);
            //command.Parameters.AddWithValue("?", lid);
            //command.Parameters.AddWithValue("?", usr._type); // isnt working
            return Edit().Result;
        }

        public override async Task<int> Remove(Entity e) { return -16; } // empty
        public override async Task<int> Update(Entity e0, Entity e1) { return -16; } // empty



        public int FindID(string uname, string cmdTxt = "SELECT *, Usr_Tbl.ID AS id FROM (Usr_Tbl INNER JOIN TypeUser_Tbl ON Usr_Tbl.ID = TypeUser_Tbl.Id)")
        {
            List<Entity> ul = SelectAll();
            int found = -1;
            foreach (User uu in ul)
            {
                if (uu._usrName == uname) found = uu._absId;
            }

            return found;
        }
    }
}
