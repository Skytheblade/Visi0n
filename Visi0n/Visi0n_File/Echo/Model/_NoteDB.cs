using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Visi0n._0.VModel;

namespace Visi0n._0.Model
{
    public class _NoteDB : BaseDB
    {
        public _NoteDB() : base() { }

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
                    tmp = CreateModel(tmp);
                    if (user._absId == tmp._uid) nl.Add(tmp);
                }
            }
            catch (Exception ex) { MessageBox.Show(" Could not load database \n Error message: \n " + ex.Message); }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return nl;
        }

        private NoteItem CreateModel(NoteItem n)
        {
            n._uid =  int.Parse(reader["Uid"].ToString());
            n._name = reader["NoteName"].ToString();
            n._text = reader["NoteText"].ToString();

            return n;
        }
    }
}
