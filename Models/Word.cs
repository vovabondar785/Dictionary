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

        public double Value { get; set; }
    }
}
