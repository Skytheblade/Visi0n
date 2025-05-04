using CoreWCF;

namespace VWS
{
    [ServiceContract]
    public interface IVisionService
    {
        [OperationContract]
        string Status();

        [OperationContract]
        bool Login(string Uname, string Upass, int T);

        [OperationContract]
        void CreatePerson(string cid, string fName, string lName, string un, string pd, int id);
    }
}
