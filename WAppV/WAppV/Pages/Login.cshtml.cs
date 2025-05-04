using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SRv1;

namespace WAppV.Pages
{
    // I have no idea what I am doing, but as long as it works it works

    public class LoginModel : PageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public async void OnGet()
        {
        }

        public async Task<bool> Call()
        {
            var client = new VisionServiceClient(VisionServiceClient.EndpointConfiguration.BasicHttpBinding_IVisionService, "http://localhost:5000/VisionService/basichttp");
            bool fl = await client.LoginAsync("DS", "pass", 1);
            if (fl) return true;
            else return false;
        }

        public async Task<string> Vortex()
        {
            string target = "Huh";
            bool f = await Call();
            if (f)
            {
                target = "Hii! :3";

            }
            return target;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostRunMethod(int a)
        {
            Username = Request.Form["N1"];
            Password = Request.Form["N2"];
            var client = new VisionServiceClient(VisionServiceClient.EndpointConfiguration.BasicHttpBinding_IVisionService, "http://localhost:5000/VisionService/basichttp");
            bool f = await client.LoginAsync(Username, Password, 1);
            if (f) { return Redirect("/ListsPage"); }
            return null;
        }
    }
}
