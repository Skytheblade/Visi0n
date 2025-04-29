using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFhost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost service = new ServiceHost(typeof(WCFcore.ServiceCore));

            Console.WriteLine("Starting service:");

            foreach (var item in service.Description.Endpoints)
            {
                Console.WriteLine(item.Address);
            }
            service.Open();
            Console.ReadLine();
        }
    }
}
