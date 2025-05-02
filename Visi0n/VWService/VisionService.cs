using CoreWCF;
using VModel_;

namespace VWS
{
    public class VisionService : IVisionService
    {
        public string Status() => "Running";

        public bool Login(string Un, string Up, int T) => UserService.LoginAtt(Un, Up, T);
    }
}
