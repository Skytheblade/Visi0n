﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using CoreWCF;

namespace VWS
{
    [DataContract]
    public class EchoFault
    {
        [DataMember]
        [AllowNull]
        public string Text { get; set; }
    }

    [ServiceContract]
    public interface IEchoService
    {
        [OperationContract]
        string Echo(string text);

        [OperationContract]
        string ComplexEcho(EchoMessage text);

        [OperationContract]
        [FaultContract(typeof(EchoFault))]
        string FailEcho(string text);

        [OperationContract]
        int SimpleCalc(int a, int b);
    }

    [DataContract]
    public class EchoMessage
    {
        [AllowNull]
        [DataMember]
        public string Text { get; set; }
    }
}