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
    }
}
