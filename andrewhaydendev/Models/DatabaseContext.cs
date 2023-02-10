using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using andrewhaydendev.Classes;
using MySql.Data.MySqlClient;
using log4net;
using log4net.Config;

namespace andrewhaydendev.Models
{
    public class DatabaseContext
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DatabaseContext));

        public string ConnectionString { get; set; }

        public DatabaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
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
                            JobTitle = reader["JobTitle"].ToString(),
                            Website = reader["Website"].ToString(),

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
                        jm.Website = reader["Website"].ToString();
					}
				}
			}

				return jm;
		}

        public MainModel GetMain()
        {
            MainModel model = new MainModel() { Resume=new List<ResumeModel>(), Skills = new List<SkillsModel>() };
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    // Get the main stuff
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM main", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Name = reader["Name"].ToString();
                            model.Titles = reader["Titles"].ToString();
                            model.Email = reader["Email"].ToString();
                            model.Phone = reader["Phone"].ToString();
                            model.GitHubLink = reader["GitHubLink"].ToString();
                            model.LinkedInLink = reader["LinkedInLink"].ToString();
                            model.ResumeLink = reader["ResumeLink"].ToString();
                            model.AboutBlurb = reader["AboutBlurb"].ToString();
                            model.AboutTitle = reader["AboutTitle"].ToString();
                            model.Birthday = reader["Birthday"].ToString().ToDateTime();
                            model.Website = reader["Website"].ToString();
                            model.CityState = reader["CityState"].ToString();
                            model.AboutStrengths = reader["AboutStrengths"].ToString();
                            model.FreelanceAvailable = reader["FreelanceAvailable"].ToString().ToBoolean();
                            model.AboutAfterBlurb = reader["AboutAfterBlurb"].ToString();
                            model.FactsBlurb = reader["FactsBlurb"].ToString();
                            model.FactsDatabases = reader["FactsDatabases"].ToString().ToInt();
                            model.FactsProjects = reader["FactsProjects"].ToString().ToInt();
                            model.FactsHoursOfCode = reader["FactsHoursOfCode"].ToString().ToInt();
                            model.FactsRunningPCs = reader["FactsRunningPCs"].ToString().ToInt();
                            model.SkillsBlurb = reader["SkillsBlurb"].ToString();
                            model.ResumeBlurb = reader["ResumeBlurb"].ToString();
                            model.ProjectsBlurb = reader["ProjectsBlurb"].ToString();
                        }
                    }

                    // Get the skills
                    List<SkillsModel> skills = new List<SkillsModel>();

                    cmd = new MySqlCommand("SELECT * FROM skills ORDER BY `Order`", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SkillsModel skill = new SkillsModel();
                            skill.ID = reader["ID"].ToString().ToInt();
                            skill.SkillName = reader["SkillName"].ToString();
                            skill.SkillPercent = reader["SkillPercent"].ToString().ToInt();
                            skill.Order = reader["Order"].ToString().ToInt();

                            skills.Add(skill);
                        }
                    }

                    model.Skills = skills;

                    // Get the resume stuff, reversed order sine the newest has the highest order number and we want that on top
                    List<ResumeModel> resumes = new List<ResumeModel>();

                    cmd = new MySqlCommand("SELECT * FROM `resume` WHERE Active = 1 ORDER BY `Order` DESC", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ResumeModel resume = new ResumeModel();
                            resume.ID = reader["ID"].ToString().ToInt();
                            resume.IsEducation = reader["IsEducation"].ToString().ToBoolean();
                            resume.Header = reader["Header"].ToString();
                            resume.Years = reader["Years"].ToString();
                            resume.Name = reader["Name"].ToString();
                            resume.CityState = reader["CityState"].ToString();
                            resume.Active = reader["Active"].ToString().ToBoolean();
                            resume.Order = reader["Order"].ToString().ToInt();
                            resume.LineItems = new List<Resume_LineItems>();

                            resumes.Add(resume);
                        }
                    }

                    foreach (ResumeModel resume in resumes)
                    {
                        cmd = new MySqlCommand("SELECT * FROM resume_lineitems WHERE ResumeID = @ResumeID ORDER BY `Order`", conn);
                        cmd.Parameters.Add(new MySqlParameter() { ParameterName = "ResumeID", Value = resume.ID });

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Resume_LineItems li = new Resume_LineItems();
                                li.ID = reader["ID"].ToString().ToInt();
                                li.ResumeID = reader["ResumeID"].ToString().ToInt();
                                li.Text = reader["Text"].ToString();
                                li.Order = reader["Order"].ToString().ToInt();

                                resume.LineItems.Add(li);
                            }
                        }
                    }

                    model.Resume = resumes;
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("MySQL Error:" + ex.Message);
                log.Error("MySQL Error", ex);
            }catch(Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                log.Error("General Error", ex);
            }
            

            return model;
        }
    }
}
