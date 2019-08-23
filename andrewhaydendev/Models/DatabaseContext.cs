using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace andrewhaydendev.Models
{
    public class DatabaseContext
    {
        public string ConnectionString { get; set; }

        public DatabaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        
        public List<ProjectModel> GetAllProjects()
        {
            List<ProjectModel> Projects = new List<ProjectModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM projects", conn);

                using(var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Projects.Add(new ProjectModel()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            RepositoryLink = reader["RepositoryLink"].ToString(),
                            CompiledProjectLink = reader["CompiledProjectLink"].ToString(),
                            ActiveDevelopment = Convert.ToBoolean(reader["ActiveDevelopment"]),
                            Description = reader["Description"].ToString(),
                            ImageURL = reader["ImageURL"].ToString().Equals(string.Empty) ? "/static/no-image-available.png" : reader["ImageURL"].ToString(),
                    }) ;
                    }
                }
            }

            return Projects;
        }

        public ProjectModel GetProjectByID(int ID)
        {
            ProjectModel pm = new ProjectModel();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM projects WHERE ID = @ProjectID", conn);
                cmd.Parameters.Add(new MySqlParameter() { ParameterName = "ProjectID", Value = ID });

                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        pm.ID = Convert.ToInt32(reader["ID"]);
                        pm.Name = reader["Name"].ToString();
                        pm.RepositoryLink = reader["RepositoryLink"].ToString();
                        pm.CompiledProjectLink = reader["CompiledProjectLink"].ToString();
                        pm.ActiveDevelopment = Convert.ToBoolean(reader["ActiveDevelopment"]);
                        pm.Description = reader["Description"].ToString();
                        pm.ImageURL = reader["ImageURL"].ToString().Equals(string.Empty) ? "/static/no-image-available.png" : reader["ImageURL"].ToString();
                        break; // This isn't necessary but I'm paranoid
                    }
                }
            }

                return pm;
        }

		public List<JobModel> GetAllJobs()
		{
			List<JobModel> Jobs = new List<JobModel>();

			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM jobs ORDER BY StartDate DESC", conn);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						DateTime startDate;
						DateTime.TryParse(reader["StartDate"].ToString(), out startDate);

						DateTime endDate;
						DateTime.TryParse(reader["EndDate"].ToString(), out endDate);
							

						Jobs.Add(new JobModel()
						{
							ID = Convert.ToInt32(reader["ID"]),
							CompanyName = reader["CompanyName"].ToString(),
							StartDate = startDate,
							EndDate = endDate,
							Description = reader["Description"].ToString(),
							JobTitle = reader["JobTitle"].ToString()
						});
					}
				}
			}
			
			return Jobs;
		}

		public JobModel GetJobByID(int ID)
		{
			JobModel jm = new JobModel();

			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM jobs WHERE ID = @JobID", conn);
				cmd.Parameters.Add(new MySqlParameter() { ParameterName = "JobID", Value = ID });

				using (var reader = cmd.ExecuteReader())
				{
					while(reader.Read())
					{
						DateTime startDate;
						DateTime.TryParse(reader["StartDate"].ToString(), out startDate);

						DateTime endDate;
						DateTime.TryParse(reader["EndDate"].ToString(), out endDate);

						jm.ID = Convert.ToInt32(reader["ID"]);
						jm.CompanyName = reader["CompanyName"].ToString();
						jm.StartDate = startDate;
						jm.EndDate = endDate;
						jm.Description = reader["Description"].ToString();
						jm.JobTitle = reader["JobTitle"].ToString();
					}
				}
			}

				return jm;
		}
    }
}
