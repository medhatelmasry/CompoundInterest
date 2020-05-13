using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config )
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index([FromQuery]string p, 
            [FromQuery]string i, 
            [FromQuery]string t, 
            [FromQuery]string y, 
            [FromQuery]string x)
        {
            CompoundInterest c = new CompoundInterest();
            if (p != null && i != null && t != null && y != null
            )
            {
                c.Principal = Convert.ToDouble(p);
                c.InterestRate = Convert.ToDouble(i);
                c.TimesCompounded = Convert.ToInt32(t);
                c.Years = Convert.ToInt32(y);
            }
            else
            {
                c.Principal = 1000;
                c.InterestRate = 5;
                c.TimesCompounded = 12;
                c.Years = 10;
            }

            if (string.IsNullOrEmpty(_config["REGION"]))
            {
                ViewBag.Region = "Environment variable REGION must be set to East or West.";
            }
            else
            {
                ViewBag.Region = _config["REGION"];
            }

            if (x != null)
            {
                string strRun = x;
                if (strRun.ToLower() == "true" || strRun.ToLower() == "yes" || strRun.ToLower() == "1")
                {
                    var result = c.CompoundInterestCalculator();

                    TempData["balance"] = result;
                }
            }


            return View(c);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CompoundInterest c)
        {
            if (ModelState.IsValid)
            {
                var result = c.CompoundInterestCalculator();

                TempData["balance"] = result.ToString();

                return RedirectToAction("Index", new { p = c.Principal, i = c.InterestRate, t = c.TimesCompounded, y = c.Years });
            }

            return View(c);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
