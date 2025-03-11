using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class Corp : User
    {
        public string _cid;
        public string _cName;

        public Corp() : base()
        {
            _cid = "_"; _cName = "";
        }
        public Corp(string cid, string cName, string un, string pd, int id) : base(un, pd, id, 2)
        {
            _cid = cid;
            _cName = cName;
        }
    }
}
