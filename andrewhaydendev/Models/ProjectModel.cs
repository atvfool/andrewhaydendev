using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace andrewhaydendev.Models
{
    public class ProjectModel : BaseModel
    {
        private RESTContext context;
        public int ID { get; set; }
        public string Name { get; set; }
        [DisplayName("Source")]
        public string RepositoryLink { get; set; }
        [DisplayName("Link")]
        public string CompiledProjectLink { get; set; }
        [DisplayName("Active")]
        public bool ActiveDevelopment { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string APIMessage { get; set; }
    }
}
