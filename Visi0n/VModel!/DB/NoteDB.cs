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
    public class NoteDB : BaseDB
    {
        public NoteDB() : base() { }

        public List<NoteItem> SelectPerId(User user, string cmdTxt = "SELECT * FROM Note_Tbl")
        {
            int id = user._absId;
            List<NoteItem> nl = new List<NoteItem>();
            List<Entity> el = base.Collect(cmdTxt);
            foreach (NoteItem n in el)
            { if (n._uid == id) nl.Add(n); }
            return nl;
        }

        public override void CreateModel(Entity e)
        {
            NoteItem n = e as NoteItem;
            n._uid = int.Parse(reader["Uid"].ToString());
            n._name = reader["NoteName"].ToString();
            n._text = reader["NoteText"].ToString();
        }

        public override List<Entity> SelectAll(string cmdTxt = "SELECT * FROM Note_Tbl")
        {
            return base.Collect(cmdTxt);
        }

        public override Entity TargetSelect(int id, string cmdTxt = "SELECT * FROM Note_Tbl")
        {
            return new NoteItem(); // also unused
        }

        protected override Entity EGen()
        {
            return new NoteItem();
        }
    }
}
