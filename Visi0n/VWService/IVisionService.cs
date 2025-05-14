using CoreWCF;
using Model_;

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

        [OperationContract]
        List<string> RemindersString(int id);

        [OperationContract]
        List<Reminder> Reminders(int id);

        [OperationContract]
        int GetID(string n);

        [OperationContract]
        List<string> EventsString(int id);

        [OperationContract]
        List<Event> Events(int id);

        [OperationContract]
        List<string> NotesString(int id);

        [OperationContract]
        List<NoteItem> Notes(int id);
    }
}
