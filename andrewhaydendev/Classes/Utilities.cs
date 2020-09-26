using andrewhaydendev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace andrewhaydendev.Classes
{
    public static class Utilities
    {
        public enum JSONDataType
        {
            GitHubRepo
        }
        private class GitHubRepo
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string html_url { get; set; }
        }

        public static List<ProjectModel> ConvertJSONToProjectModel(string json, JSONDataType dataType)
        {
            List<ProjectModel> Projects = new List<ProjectModel>();

            switch (dataType)
            {
                case JSONDataType.GitHubRepo:
                    List<GitHubRepo> repos = JsonConvert.DeserializeObject<List<GitHubRepo>>(json);

                    repos.ForEach(x => Projects.Add(new ProjectModel
                    {
                        ID = x.id,
                        Name = x.name,
                        Description = x.description,
                        RepositoryLink = x.html_url,
                        ActiveDevelopment = false,
                        ImageURL = "/static/no-image-available.png"
                    }));
                    break;
            }

            return Projects;
        }
    }
}
