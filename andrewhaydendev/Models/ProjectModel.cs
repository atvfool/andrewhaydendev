using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace andrewhaydendev.Models
{
    public class ProjectModel
    {
        private DatabaseContext context;
        public int ID { get; set; }
        public string Name { get; set; }
        public string RepositoryLink { get; set; }
        public string CompiledProjectLink { get; set; }
        public bool ActiveDevelopment { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
