using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace andrewhaydendev.Models
{
    public class ResumeModel
    {
        public int ID { get; set; }
        public bool IsEducation { get; set; }
        public string Header { get; set; }
        public string Years { get; set; }
        public string Name { get; set; }
        public string CityState { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public List<Resume_LineItems> LineItems { get; set; }
    }
}
