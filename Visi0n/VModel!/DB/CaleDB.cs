using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model_;

namespace VModel_
{
    public class CaleDb : BaseDB
    {
        public CaleDb() : base() { }

        public ObservableCollection<Event> SelectPerId(User user, string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            int id = user._absId;
            command.CommandText = cmdTxt;
            ObservableCollection<Event> nl = new ObservableCollection<Event>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                Event tmp = new Event();

                while (reader.Read())
                {
                    tmp = new Event();
                    CreateModel(tmp);
                    if (user._absId == tmp._uid) nl.Add(tmp);
                }
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return nl;
        }

        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            return base.Collect(cmdTxt);
        }

        public override void CreateModel(Entity e)
        {
            Event n = e as Event;
            n._uid = int.Parse(reader["Uid"].ToString());
            n._name = reader["EventName"].ToString();
            n._description = reader["EventContent"].ToString();
            n._date = reader["EventDate"].ToString();
            n._ID = int.Parse(reader["ID"].ToString());
        }

        protected override Entity EGen()
        {
            return new Event();
        }


        public int ReturnNextID(string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            command.CommandText = cmdTxt;
            int nMax = 0;

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nMax++;
                }

                nMax++;
            }
            catch (Exception ex) { Console.WriteLine(" Could not load database \n Error message: \n " + ex.Message); }
            finally
            {
                CloseSetup();
            }
            return nMax;
        }
    }
}
