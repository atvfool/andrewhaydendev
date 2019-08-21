using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using andrewhaydendev.Models;

namespace andrewhaydendev.Controllers
{
    public class JobsController : Controller
    {
        public ActionResult Index()
        {
			DatabaseContext context = HttpContext.RequestServices.GetService(typeof(DatabaseContext)) as DatabaseContext;

			return View(context.GetAllJobs());
        }

		public ActionResult Details(int id)
		{
			DatabaseContext context = HttpContext.RequestServices.GetService(typeof(DatabaseContext)) as DatabaseContext;

			return View(context.GetJobByID(id));
		}
    }
}