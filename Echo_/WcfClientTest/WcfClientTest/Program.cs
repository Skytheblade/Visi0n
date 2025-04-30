using System;
using System.ServiceModel;
using WcfClientTest.ServiceReference1;

class Program
{
    static void Main()
    {
        ChannelFactory<IMathService> factory = new ChannelFactory<IMathService>(
            new BasicHttpBinding(),
            new EndpointAddress("http://localhost:8080/MathService"));

        IMathService proxy = factory.CreateChannel();

        int result = proxy.Add(5, 7);
        Console.WriteLine("5 + 7 = " + result);
        Console.ReadLine();

        ((IClientChannel)proxy).Close();
        factory.Close();
    }
}