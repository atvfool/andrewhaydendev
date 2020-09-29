using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace andrewhaydendev.Models
{
	public class JobModel
	{
		private DatabaseContext context;
		public int ID { get; set; }
		public string CompanyName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Description { get; set; }
		public string JobTitle { get; set; }
		public string Website { get; set; }
	}
}
