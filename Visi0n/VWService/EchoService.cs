using CoreWCF;


namespace VWS
{
    public class EchoService : IEchoService
    {
        public string Echo(string text)
        {
            System.Console.WriteLine($"Received {text} from client!");
            return text;
        }

        public string ComplexEcho(EchoMessage text)
        {
            System.Console.WriteLine($"Received {text.Text} from client!");
            return text.Text;
        }

        public int SimpleCalc(int a, int b)
        {
            Console.WriteLine("" + a + " + " + b + " = " + (a + b));
            return a + b;
        }

        public string FailEcho(string text)
            => throw new FaultException<EchoFault>(new EchoFault() { Text = "WCF Fault OK" }, new FaultReason("FailReason"));

    }
}