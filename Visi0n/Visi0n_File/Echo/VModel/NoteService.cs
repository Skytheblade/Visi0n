using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visi0n._0.Model;

namespace Visi0n._0.VModel
{
    internal class NoteService
    {
        public static List<NoteItem> GetNotes(User user)
        {
            List<NoteItem> list = new _NoteDB().SelectPerId(user);
            return list;
        }
    }
}
