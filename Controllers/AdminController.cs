using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}