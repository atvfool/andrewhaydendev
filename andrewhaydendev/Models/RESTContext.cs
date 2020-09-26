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
        public RESTContext()
        {
        }

        private async Task<string> callAPI(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-agent", "atvfool-browser");
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
                client.DefaultRequestHeaders.Add("User-agent", "atvfool-browser");
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

            Projects = Utilities.ConvertJSONToProjectModel(await callAPI("https://api.github.com/users/atvfool/repos?type=owner&per_page=100"), Utilities.JSONDataType.GitHubRepo);
           

            return Projects;
        }

        public ProjectModel GetProjectByID(int ID)
        {
            ProjectModel pm = new ProjectModel();

            //using (MySqlConnection conn = GetConnection())
            //{
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM projects WHERE ID = @ProjectID", conn);
            //    cmd.Parameters.Add(new MySqlParameter() { ParameterName = "ProjectID", Value = ID });

            //    using (var reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            pm.ID = Convert.ToInt32(reader["ID"]);
            //            pm.Name = reader["Name"].ToString();
            //            pm.RepositoryLink = reader["RepositoryLink"].ToString();
            //            pm.CompiledProjectLink = reader["CompiledProjectLink"].ToString();
            //            pm.ActiveDevelopment = Convert.ToBoolean(reader["ActiveDevelopment"]);
            //            pm.Description = reader["Description"].ToString();
            //            pm.ImageURL = reader["ImageURL"].ToString().Equals(string.Empty) ? "/static/no-image-available.png" : reader["ImageURL"].ToString();
            //            break; // This isn't necessary but I'm paranoid
            //        }
            //    }
            //}

            return pm;
        }

        public List<JobModel> GetAllJobs()
        {
            List<JobModel> Jobs = new List<JobModel>();

            //using (MySqlConnection conn = GetConnection())
            //{
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM jobs ORDER BY StartDate DESC", conn);

            //    using (var reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            DateTime startDate;
            //            DateTime.TryParse(reader["StartDate"].ToString(), out startDate);

            //            DateTime endDate;
            //            DateTime.TryParse(reader["EndDate"].ToString(), out endDate);


            //            Jobs.Add(new JobModel()
            //            {
            //                ID = Convert.ToInt32(reader["ID"]),
            //                CompanyName = reader["CompanyName"].ToString(),
            //                StartDate = startDate,
            //                EndDate = endDate,
            //                Description = reader["Description"].ToString(),
            //                JobTitle = reader["JobTitle"].ToString()
            //            });
            //        }
            //    }
            //}

            return Jobs;
        }

        public JobModel GetJobByID(int ID)
        {
            JobModel jm = new JobModel();

            //using (MySqlConnection conn = GetConnection())
            //{
            //    conn.Open();
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM jobs WHERE ID = @JobID", conn);
            //    cmd.Parameters.Add(new MySqlParameter() { ParameterName = "JobID", Value = ID });

            //    using (var reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            DateTime startDate;
            //            DateTime.TryParse(reader["StartDate"].ToString(), out startDate);

            //            DateTime endDate;
            //            DateTime.TryParse(reader["EndDate"].ToString(), out endDate);

            //            jm.ID = Convert.ToInt32(reader["ID"]);
            //            jm.CompanyName = reader["CompanyName"].ToString();
            //            jm.StartDate = startDate;
            //            jm.EndDate = endDate;
            //            jm.Description = reader["Description"].ToString();
            //            jm.JobTitle = reader["JobTitle"].ToString();
            //        }
            //    }
            //}

            return jm;
        }
    }
}
