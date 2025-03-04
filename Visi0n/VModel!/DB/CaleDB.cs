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
            ObservableCollection<Event> nl = new ObservableCollection<Event>();
            List<Entity> el = base.Collect(cmdTxt);
            foreach (Event e in el)
            { if (e._uid == id) nl.Add(e); }
            return nl;
        }

        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            return base.Collect(cmdTxt);
        }

        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            List<Entity> cl = base.Collect(cmdTxt);
            foreach (Event e in cl)
            { if (e._ID == id) return e; }
            return new Event();
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

        public int FindID(string ename, User u, string date, string cmdTxt = "SELECT * FROM Cale_Tbl")
        {
            List<Entity> el = SelectAll();
            int found = -1;
            foreach (Event e in el)
            {
                if (u._absId == e._uid && ename == e._name && date == e._date) found = e._ID;
            }
            return found;
        }
    }
}
