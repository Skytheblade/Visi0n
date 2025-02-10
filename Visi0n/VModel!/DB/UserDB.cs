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
        public UserDB() : base() { }

        public User SelectLast(int id, string cmdTxt = "SELECT * FROM Usr_Tbl")
        {
            command.CommandText = cmdTxt;
            User usr = new User();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                User tmp = new User();

                while (reader.Read()) // each new reader line - each progression
                {
                    tmp = new User();
                    tmp = CreateModel(tmp);
                }
                usr = tmp;
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); } // print error if is
            finally // close
            {
                CloseSetup();
            }
            return usr;
        }

        public User TargetSelect(int id, string cmdTxt = "SELECT * FROM Usr_Tbl")
        {
            command.CommandText = cmdTxt;
            User usr = new User();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                User tmp = new User();

                while (reader.Read())
                {
                    tmp = new User();
                    tmp = CreateModel(tmp);

                    if (tmp._absId == id) usr = tmp; // from all the table select the last with id - find single correct instance
                }
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); }
            finally
            {
                CloseSetup();
            }
            return usr;
        }

        public User CreateModel(User u)
        {
            u._usrName = reader["UserName"].ToString();
            u._pwd = reader["PassCode"].ToString();
            u._absId = int.Parse(reader["ID"].ToString());
            u._type = int.Parse(reader["UserType"].ToString());

            return u;
        }


        public List<User> Collect(string cmdTxt = "SELECT * FROM Usr_Tbl")
        {
            command.CommandText = cmdTxt;
            List<User> ul = new List<User>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                User tmp = new User();

                while (reader.Read()) // each new reader line - each progression
                {
                    tmp = new User();
                    tmp = CreateModel(tmp);
                    ul.Add(tmp);
                }
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); } // print error if is
            finally // close
            {
                CloseSetup();
            }

            return ul;
        }


        protected async Task<int> Edit(string sqlStr, int records = 0)
        {
            trans = null;
            try
            {
                command.CommandText = sqlStr;
                connection.Open();
                trans = connection.BeginTransaction();
                command.Transaction = trans;
                records = command.ExecuteNonQuery(); // action; +Async & await for later
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                Console.WriteLine("Error message: \n " + e.Message);
            }
            finally
            {
                CloseSetup();
            }
            return records;
        }

        public async Task<int> Insert(User usr)
        {
            int records = 0;

            string sqlStr = string.Format("INSERT INTO Usr_Tbl (UserName, PassCode, UserType) "
                + "VALUES ('{0}', '{1}', {2});",
            /*usr._absId,*/
            usr._usrName, usr._pwd, usr._type);

            //do not insert autonumber, and do not use 'Password' fields (syntax error)

            return Edit(sqlStr, records).Result;
        }

        /*public async Task<int> Update(People usr)
        {
            int records = 0;

            string sqlStr = $"UPDATE peopleTBL SET " +
                $"firstName = '{prsn.firstName}'," +
                $" lastName = '{prsn.lastName}'," +
                $" city = '{prsn.city.cityname}'," +
                $" telephone = '{prsn.telephone}'" +
                $" WHERE UID = '{prsn.id}'";

            return Edit(sqlStr, records).Result;
        }

        public async Task<int> Remove(string uid)
        {
            int records = 0;

            string sqlStr = $"DELETE FROM peopleTBL WHERE UID = '{uid}'";

            return Edit(sqlStr, records).Result;
        }*/


        public int FindID(string uname, string cmdTxt = "SELECT * FROM Usr_Tbl")
        {
            List<User> ul = Collect();
            int found = -1;
            foreach (User uu in ul)
            {
                if (uu._usrName == uname) found = uu._absId;
            }

            return found;
        }
    }
}
