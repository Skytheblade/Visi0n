using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VModel_;


namespace WCFcore
{
    internal class ServiceCore : IWebService
    {
        public bool Login(string Un, string Up, int t) => UserService.LoginAtt(Un, Up, t);
    }
}
