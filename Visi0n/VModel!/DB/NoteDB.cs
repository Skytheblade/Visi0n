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
    public class NoteDB : BaseDB
    {
        public NoteDB() : base() { }

        public List<NoteItem> SelectPerId(User user, string cmdTxt = "SELECT * FROM Note_Tbl")
        {
            int id = user._absId;
            command.CommandText = cmdTxt;
            List<NoteItem> nl = new List<NoteItem>();

            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                NoteItem tmp = new NoteItem();

                while (reader.Read())
                {
                    tmp = new NoteItem();
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

        public override void CreateModel(Entity e)
        {
            NoteItem n = e as NoteItem;
            n._uid = int.Parse(reader["Uid"].ToString());
            n._name = reader["NoteName"].ToString();
            n._text = reader["NoteText"].ToString();
        }
    }
}
