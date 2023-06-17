using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using andrewhaydendev.Models;
using andrewhaydendev.Classes;

namespace andrewhaydendev.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DatabaseContext context = HttpContext.RequestServices.GetService(typeof(DatabaseContext)) as DatabaseContext;

            MainModel model = context.GetMain();

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

        public IActionResult GeneratePDF()
        {
            PDFGenerator.Generator();
            return View();
        }
    }
}
