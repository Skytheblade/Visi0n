using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFcore
{
    [ServiceContract]
    interface IWebService
    {
        
        [OperationContract]
        bool Login(string Uname, string Upass, int Uvar);
    }
}
