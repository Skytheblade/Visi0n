using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WAppV.Pages
{
    public class RandomUserApiModel : PageModel
    {
        public string InputText { get; set; }
        public string Result { get; set; }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            var action = Request.Form["action"];
            if (action == "b1")
            {
                // register

            }
            // else pass
        }

        // returns a list (async) of parts of a user
        public  async Task<List<string>> Create()
        {
            string apiUrl = "https://randomuser.me/api/?results=1&nat=us"; // 1 person (from us)
            string fn = "";
            string ln = "";
            string u = "";
            string p = "";
            List<string> list = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode) // if there is a result
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Parse
                    RootObject0j rootObject = JsonConvert.DeserializeObject<RootObject0j>(jsonResponse);

                    // loop for the case of more than 1 person
                    foreach (var result in rootObject.results)
                    {
                        //lLl += ($"Name: {result.name.first} {result.name.last}; {result.login.username} {result.login.password}");
                        fn += result.name.first; ln += result.name.last; u += result.login.username; p += result.login.password;
                        // since there is only 1 result there is no meaning in changing it
                    }
                    list.Add(fn); list.Add(ln); list.Add(u); list.Add(p);
                }
                else
                {
                    Console.WriteLine("Error fetching data.");
                }
            }

            return list;
        }

        // individual parts, might improve
        public async Task<string> GetFName()
        {
            List<string> list = await Create();
            return list[0];
        }
        public async Task<string> GetLName()
        {
            List<string> list = await Create();
            return list[1];
        }
        public async Task<string> GetUName()
        {
            List<string> list = await Create();
            return list[2];
        }
        public async Task<string> GetPCode()
        {
            List<string> list = await Create();
            return list[3];
        }
    }

    // result object model
    public class RootObject0j
    {
        public List<Result0j> results { get; set; }
    }
    public class Result0j
    {
        public Name0j name { get; set; }
        public string email { get; set; }
        public Login0j login { get; set; }
    }
    public class Name0j
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }
    public class Login0j
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
