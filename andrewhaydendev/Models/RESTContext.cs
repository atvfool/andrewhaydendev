using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using andrewhaydendev.Classes;
//using Microsoft.AspNetCore.Mvc.Internal;
using Newtonsoft.Json;

namespace andrewhaydendev.Models
{
    public class RESTContext
    {
        #region Enums
        public enum JSONDataType
        {
            GitHubRepo
        }
        #endregion
        public RESTContext()
        {
        }

        private async Task<string> callAPI(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-agent", "arhayden-browser");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                using (var response = await client.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }

            }
        }

        private async Task<string> callAPI(string apiUrl, List<KeyValuePair<string, string>> data)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-agent", "arhayden-browser");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                StringContent stringContent = new StringContent("");
                data.ForEach(x => stringContent.Headers.Add(x.Key, x.Value));
                using (var response = await client.PostAsync(apiUrl, stringContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }

            }

        }
       
        public async Task<List<ProjectModel>> GetAllProjects()
        {
            List<ProjectModel> Projects = new List<ProjectModel>();

            Projects = ConvertJSONToProjectModel(await callAPI("https://api.github.com/users/atvfool/repos?type=owner&per_page=100&affiliation=owner"), JSONDataType.GitHubRepo);
           

            return Projects;
        }

        #region GitHub Stuff

        private class GitHubRepo
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string html_url { get; set; }
            public bool fork { get; set; }
            public DateTime pushed_at { get; set; }
            public string homepage { get; set; }
        }

        public static List<ProjectModel> ConvertJSONToProjectModel(string json, JSONDataType dataType)
        {
            List<ProjectModel> Projects = new List<ProjectModel>();
            string searchCharater = "{|}"; // I'd rather not make a whole another API for each object to find the ones I actually want to display so since I have control of the data I will just insert this character into the description of the repo. 

            switch (dataType)
            {
                case JSONDataType.GitHubRepo:
                    List<GitHubRepo> repos = JsonConvert.DeserializeObject<List<GitHubRepo>>(json);

                    repos.Where(x => !x.fork && x.description != null && x.description.Contains(searchCharater)).ToList().ForEach(x => Projects.Add(new ProjectModel
                    {
                        ID = x.id,
                        Name = x.name,
                        Description = x.description.Replace(searchCharater, ""), // remove that searchCharacter so it looks cleaner. 
                        RepositoryLink = x.html_url,
                        ActiveDevelopment = (DateTime.Now - x.pushed_at).Days < 180 ? true : false,
                        CompiledProjectLink = x.homepage,
                        ImageURL = "/static/no-image-available.png" // I'll figure something out to display with this projects, or maybe i'll remove the images all together
                    }));
                    break;
            }

            return Projects;
        }

        #endregion

    }
}
