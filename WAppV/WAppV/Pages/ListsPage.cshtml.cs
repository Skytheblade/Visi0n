using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SRv1;

namespace WAppV.Pages
{
    public class ListsPageModel : PageModel
    {
        public async void OnGet()
        {
            
        }

        public async Task<string> Remind(int id)
        {
            var client = new VisionServiceClient(VisionServiceClient.EndpointConfiguration.BasicHttpBinding_IVisionService, "http://localhost:5000/VisionService/basichttp");
            var list = await client.RemindersStringAsync(id);
            string longstring = "";
            foreach (string s in list) { longstring += ("" + s + "\n\n"); }
            return longstring;
        }
    }
}
