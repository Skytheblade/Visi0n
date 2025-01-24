using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VModel_
{
    public class PersonalDB : BaseDB
    {
        public PersonalDB() : base() { }

        public List<Person> Collect(string cmdTxt = "SELECT * FROM Personal_Tbl")
        {
            command.CommandText = cmdTxt;
            List<Person> pl = new List<Person>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                Person tmp = new Person();

                while (reader.Read())
                {
                    tmp = new Person();
                    tmp = CreateModel(tmp);
                    pl.Add(tmp);
                }
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); }
            finally { CloseSetup(); }

            return pl;
        }

        private Person CreateModel(Person p)
        {
            p._absId = int.Parse(reader["ID"].ToString());

            User u = new UserDB().TargetSelect(p._absId); // !
            p._usrName = u._usrName;
            p._pwd = u._pwd;
            p._type = 1;

            p._fName = reader["FirstName"].ToString();
            p._lName = reader["LastName"].ToString();
            p._cid = reader["Corp"].ToString();

            return p;
        }

        public Person TargetSelect(int id, string cmdTxt = "SELECT * FROM Usr_Tbl")
        {
            command.CommandText = cmdTxt;
            Person p = new Person();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                Person tmp = new Person();

                while (reader.Read())
                {
                    tmp = new Person();
                    tmp = CreateModel(tmp);

                    if (tmp._absId == id) p = tmp;
                }
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); }
            finally { CloseSetup(); }
            return p;
        }
    }
}
