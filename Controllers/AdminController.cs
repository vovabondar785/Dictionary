using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Interfaces;
using Dictionary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWords words;

        public IActionResult Panel()
        {
            return View();
        }

        public IActionResult AddWord(Word w)
        {
            words.AddWord(w);

            return RedirectToAction("Panel", "Admin");
        }
    }
}