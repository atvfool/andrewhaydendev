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
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Projects", conn);

                using(var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Projects.Add(new ProjectModel()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString()
                        }) ;
                    }
                }
            }

            return Projects;
        }
    }
}
