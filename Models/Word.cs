using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Models
{
    public class Word
    {
        public int ID { get; set; }

        public string EnglishValue { get; set; }

        public string RussianValue { get; set; }

        public int ValueEng { get; set; }

        public int ValueRus { get; set; }
    }
}
