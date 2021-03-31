using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.gra;
using Logic.gra;
using Models.gra;

namespace Wapp.gt.Controllers
{
    public class AccountController : Controller
    {
   
        public IActionResult Login()
        {
            return View();
        }
   
    }
}
