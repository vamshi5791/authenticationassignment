using DotNetCoreDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [TypeFilter(typeof(AuthorizeMe))]

        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("Login_status") != null)
            {
                ViewBag.Status = "LoggedIn";
            }
            else
            {
                ViewBag.Status = "NotLoggedIn";

            }


            return View();
        }
        public ActionResult Login(LoginModel data)
        {
            if (data.username == "abc" && data.possword == "abc")
            {
                HttpContext.Session.SetString("Login_status", "1");
            }
            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
           // ViewBag.user = Request.Cookies["UserName"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
