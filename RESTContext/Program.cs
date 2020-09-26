using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RESTContext
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await (new API()).CallAPI();

            Console.ReadLine();
        }

    }

    class API
    {
        public async Task CallAPI()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-agent", "atvfool");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");

                using (var response = await httpClient.GetAsync("https://api.github.com/users/atvfool/repos?type=owner&per_page=100"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    var repos = JsonConvert.DeserializeObject<List<response>>(apiResponse);

                    foreach(response repo in repos)
                    {
                        Console.WriteLine("{0}: {1}\n{2}\n-----------------------", repo.name, repo.html_url, repo.description);
                    }
                }
            }
        }
    }

    class response
    {
        public string name { get; set; }
        public string description { get; set; }
        public string html_url { get; set; }
    }
}
