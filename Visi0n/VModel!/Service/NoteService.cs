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
    }
}
