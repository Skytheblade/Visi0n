using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Visi0n._0.VModel;

namespace Visi0n._0.Model
{
    public class _UserDB : BaseDB
    {
        public _UserDB() : base() { /*this.uidArr = this.ArchRun(); this.uidNext = (uidArr.Max() + 1).ToString();*/ }

        public User SelectLast(int id, string cmdTxt = "SELECT * FROM Usr_Tbl")
        {
            command.CommandText = cmdTxt;
            User usr = new User();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                //asncReader = await command.ExecuteReaderAsync();
                User tmp = new User();

                while (reader.Read()) // each new reader line - each progression
                {
                    tmp = new User();
                    tmp = CreateModel(tmp); // set to current line
                }
                usr = tmp;
            }
            catch (Exception ex) { MessageBox.Show(" Could not load database \n Error message: \n " + ex.Message); } // print error if is
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
                //asncReader = await command.ExecuteReaderAsync();
                User tmp = new User();

                while (reader.Read())
                {
                    tmp = new User();
                    tmp = CreateModel(tmp);

                    if (tmp._absId == id) usr = tmp; // from all the table select the last with id - find single correct instance
                }
            }
            catch (Exception ex) { MessageBox.Show(" Could not load database \n Error message: \n " + ex.Message); }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return usr;
        }

        /*protected async Task<PeopleList> Select(string cmdTxt = "SELECT * FROM peopleTBL")
        {
            command.CommandText = cmdTxt;
            PeopleList people = new PeopleList();

            try
            {
                command.Connection = connection;
                connection.Open();
                asncReader = await command.ExecuteReaderAsync();
                People prsn;

                while (asncReader.Read())
                {
                    prsn = new People();
                    people.Add((People)CreateModel(prsn));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(" Could not load database \n Error message: \n " + e.Message);
            }
            finally
            {
                if (asncReader != null) asncReader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return people;
        }*/

        private User CreateModel(User u) // could also be void
        {
            //prsn = (User)(base.CreateModel(prsn));
            u._usrName = reader["UserName"].ToString();
            u._pwd = reader["Password"].ToString();
            u._absId = int.Parse(reader["ID"].ToString());
            
            return u;
        }

        //public PeopleList SelectAll() => Select().Result;

        /*protected override int[] ArchRun() // just to make a uid :|
        {
            command.CommandText = "SELECT * FROM peopleTBL";
            PeopleList people = Select().Result;

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                this.uidArr = new int[people.Count];
                int x = 0;
                while (reader.Read())
                {
                    uidArr[x] = int.Parse(reader["UID"].ToString()); // no null coverage yet
                    x++;
                }
            }
            catch (Exception e) { MessageBox.Show("Error message: \n " + e.Message); }
            if (reader != null) reader.Close();
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();

            return this.uidArr;
        }*/


        /*protected async Task<int> ActionIUR(string sqlStr, int records = 0)
        {
            trans = null;
            try
            {
                command.CommandText = sqlStr;
                connection.Open();
                trans = connection.BeginTransaction();
                command.Transaction = trans;
                records = await command.ExecuteNonQueryAsync();
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                MessageBox.Show("Error message: \n " + e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return records;
        }*/

        /*public async Task<int> Insert(People prsn, string uid)
        {
            int records = 0;

            string sqlStr = string.Format("INSERT INTO peopleTBL (UID, firstName, lastName, city, telephone) "
                + "VALUES('{4}', '{0}', '{1}', '{2}', '{3}')",
                prsn.firstName, prsn.lastName, prsn.city.cityname, prsn.telephone, uid);

            return ActionIUR(sqlStr, records).Result;
        }*/

        /*public async Task<int> Update(People prsn)
        {
            int records = 0;

            string sqlStr = $"UPDATE peopleTBL SET " +
                $"firstName = '{prsn.firstName}'," +
                $" lastName = '{prsn.lastName}'," +
                $" city = '{prsn.city.cityname}'," +
                $" telephone = '{prsn.telephone}'" +
                $" WHERE UID = '{prsn.id}'";

            return ActionIUR(sqlStr, records).Result;
        }*/

        /*public async Task<int> Remove(string uid)
        {
            int records = 0;

            string sqlStr = $"DELETE FROM peopleTBL WHERE UID = '{uid}'";

            return ActionIUR(sqlStr, records).Result;
        }*/
    }
}
