using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visi0nClient.ServiceReference1;

namespace Visi0nClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceClient client = new WebServiceClient();

            bool test = client.Login("DS", "pass", 1);
            Console.WriteLine(test);

            client.Close();
        }
    }
}
