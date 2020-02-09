using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult HomePage()
        {
            List<Word> words = new List<Word>();
            words.Add(new Word
            {
                ID=1,
                RussianValue="слово",
                EnglishValue="word"
            });
            words.Add(new Word
            {
                ID = 1,
                RussianValue = "песня",
                EnglishValue = "song"
            });
            words.Add(new Word
            {
                ID = 1,
                RussianValue = "дерево",
                EnglishValue = "tree"
            });
            words.Add(new Word
            {
                ID = 1,
                RussianValue = "дом",
                EnglishValue = "house"
            });
            return View(words);
        }
    }
}