using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model_
{
    /// <summary>
    /// A control unit user - all (corp) are (user)
    /// </summary>
    public class Corp : User
    {
        // function as cosmetic in relation to users; alternative control over users (self & other compared to self)

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
        public Corp(User u, string id, string cn) : base(u._usrName, u._pwd, u._absId, 1)
        {
            _cid = id;
            _cName = cn;
        }
    }
}
