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
            words.Add(new Word
            {
                ID=1,
                RussianValue="слово",
                EnglishValue="word",
                ValueEng=1,
                ValueRus=1
            });
            words.Add(new Word
            {
                ID = 2,
                RussianValue = "песня",
                EnglishValue = "song",
                ValueEng = 1,
                ValueRus = 1
            });
            words.Add(new Word
            {
                ID = 3,
                RussianValue = "дерево",
                EnglishValue = "tree",
                ValueEng = 1,
                ValueRus = 1
            });
            words.Add(new Word
            {
                ID = 4,
                RussianValue = "дом",
                EnglishValue = "house",
                ValueEng = 1,
                ValueRus = 1
            });
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
            var ret = list.GetRange(0, 4);
            list.RemoveRange(0, 4);
            return View(ret);
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