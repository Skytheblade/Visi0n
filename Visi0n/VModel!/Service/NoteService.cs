using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VModel_
{
    public class NoteService
    {
        public static List<NoteItem> GetNotes(User user)
        {
            List<NoteItem> list = new NoteDB().SelectPerId(user);
            return list;
        }

        public static void WriteNote(NoteItem n)
        {
            new NoteDB().Insert(n);
        }

        public static void DeleteNote(NoteItem n)
        {
            new NoteDB().Remove(n);
        }

        public static void UpdateNote(NoteItem n, string name, string txt)
        {
            new NoteDB().Update(n, new NoteItem(name, txt, n._uid));
        }

        public static NoteItem Find(User u, string name)
        {
            List<Entity> nl = new NoteDB().SelectAll();
            NoteItem nn = new NoteItem();
            foreach (NoteItem n in nl) { if (n._uid == u._absId && n._name == name) nn = n; }
            return nn;
        }

        public static void ScrapWrite(string Name, string Text, int Uid, string Cid = "--")
        {
            NoteItem nt = new NoteItem(Name, Text, Uid, Cid);
            WriteNote(nt);
        }
    }
}
