using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wapp.gt.Models;
using wapp.gt.Models;

namespace Wapp.gt.Controllers
{
    public class HomeController : Controller
    {
        
        public static string credentialsPath = "credentials.json";
        GoogleCalendar MyCalendar = new GoogleCalendar(credentialsPath);
        public IActionResult Index()
        {
            return View(MyCalendar.VerEventos());
        }

        public IActionResult MostrarEventos() {
            return View(MyCalendar.VerEventos());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Prueba()
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
