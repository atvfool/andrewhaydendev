using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using andrewhaydendev.Models;
using andrewhaydendev.Services;

namespace andrewhaydendev.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDapper _dapper;
        public HomeController(IDapper dapper)
        {
            _dapper = dapper;
        }

        public IActionResult Index()
        {
            // DatabaseContext context = HttpContext.RequestServices.GetService(typeof(DatabaseContext)) as DatabaseContext;

            MainModel result = _dapper.Get<MainModel>("SELECT * FROM main");
            result.Skills = _dapper.GetAll<SkillsModel>("SELECT * FROM skills");
            result.Resume = _dapper.GetAll<ResumeModel>("SELECT * FROM resume WHERE Active = 1 ORDER BY `Order` DESC");

            foreach(ResumeModel resume in result.Resume)
            {
                Dapper.DynamicParameters dynamicParameters = new Dapper.DynamicParameters();
                dynamicParameters.Add("ResumeID", resume.ID);
                resume.LineItems = _dapper.GetAll<Resume_LineItems>("SELECT * FROM resume_lineitems WHERE ResumeID = @ResumeID ORDER BY `Order` DESC", dynamicParameters);
            }

            MainModel model = result;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> GetProjects()
        {
            RESTContext context = HttpContext.RequestServices.GetService(typeof(RESTContext)) as RESTContext;

            return PartialView("_PartialProject", await context.GetAllProjects());
        }
    }
}
