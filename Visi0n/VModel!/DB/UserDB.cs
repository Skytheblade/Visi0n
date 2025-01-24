using System;
using System.Collections.Generic;
using System.Linq;
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
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
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
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return usr;
        }

        public User CreateModel(User u)
        {
            u._usrName = reader["UserName"].ToString();
            u._pwd = reader["Password"].ToString();
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
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return ul;
        }
    }
}
