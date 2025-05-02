using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WcfTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MathService),
            new Uri("http://localhost:8080/MathService")))
            {
                host.AddServiceEndpoint(typeof(IMathService), new BasicHttpBinding(), "");

                // Add metadata exchange (WSDL)
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Add MEX endpoint
                host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                    MetadataExchangeBindings.CreateMexHttpBinding(),
                    "mex");

                host.Open();

                Console.WriteLine("Service is running...");
                Console.ReadLine();
            }
        }
    }

    public class MathService : IMathService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        int Add(int a, int b);
    }
}