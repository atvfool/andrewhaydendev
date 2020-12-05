using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace andrewhaydendev.Models
{
    public class MainModel
    {
        public string Name { get; set; }
        public string Titles { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GitHubLink { get; set; }
        public string LinkedInLink { get; set; }
        public string AboutBlurb { get; set; }
        public string AboutTitle { get; set; }
        public DateTime Birthday{ get; set; }
        public string Website { get; set; }
        public string CityState { get; set; }
        public string AboutStrengths { get; set; }
        public bool FreelanceAvailable { get; set; }
        public string AboutAfterBlurb { get; set; }
        public string FactsBlurb { get; set; }
        public int FactsDatabases { get; set; }
        public int FactsProjects { get; set; }
        public int FactsHoursOfCode { get; set; }
        public int FactsRunningPCs { get; set; }
        public string SkillsBlurb { get; set; }
        public string ResumeBlurb { get; set; }
        public string ProjectsBlurb { get; set; }
        public List<SkillsModel> Skills { get; set; }
        public List<ResumeModel> Resume { get; set; }
    }
}
