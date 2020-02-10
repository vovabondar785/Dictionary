using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Models
{
    public class WordReturnModel
    {

        public string Value { get; set; }

        public string Lang { get; set; }

        public int Id { get; set; }

        public int Cnt { get; set; }

        public string FontSize { get { return (25 + 5 * Cnt)+"px"; } set { } }

    }
}
