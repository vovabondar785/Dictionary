using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dictionary.Controllers
{
    public class HomeController : Controller
    {
        public static List<WordReturnModel> list = new List<WordReturnModel>();

        public static List<Word> words = new List<Word>();

        [HttpGet]
        public IActionResult HomePage()
        {
            words.Clear();
            words.Add(new Word
            {
                ID=1,
                RussianValue="слово",
                EnglishValue="word",
                ValueEng=2,
                ValueRus=10
            });
            words.Add(new Word
            {
                ID = 2,
                RussianValue = "песня",
                EnglishValue = "song",
                ValueEng = 4,
                ValueRus = 1
            });
            words.Add(new Word
            {
                ID = 3,
                RussianValue = "дерево",
                EnglishValue = "tree",
                ValueEng = 8,
                ValueRus = 5
            });
            words.Add(new Word
            {
                ID = 4,
                RussianValue = "дом",
                EnglishValue = "house",
                ValueEng = 2,
                ValueRus = 10
            });
            list.Clear();
            foreach(var w in words)
            {
                list.Add(new WordReturnModel
                {
                    Id=w.ID,
                    Lang="rus",
                    Cnt=w.ValueRus,
                    Value=w.RussianValue
                });
                list.Add(new WordReturnModel
                {
                    Id = w.ID,
                    Lang = "en",
                    Cnt = w.ValueEng,
                    Value = w.EnglishValue
                });
            }
            return View(list);
        }

        public JsonResult Check(int Id,string Lang,string Value)
        {
            var word = words.Find(w => w.ID == Id);
            switch (Lang)
            {
                case "en":
                    if(word.RussianValue.ToLower()!=Value.ToLower())
                    {
                        return Json("not");
                    }
                    break;
                case "rus":
                    if (word.EnglishValue.ToLower() != Value.ToLower())
                    {
                        return Json("not");
                    }
                    break;
                default:
                    return Json("error");
            }
            if (list.Count != 0)
            {
                var ans = list[0];
                list.RemoveAt(0);
                string ret = JsonConvert.SerializeObject(ans);
                return Json(ret);
            }
            return Json("no_words");
        }
    }
}