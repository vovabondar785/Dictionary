using Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Interfaces
{
    interface IWords
    {
        public IEnumerable<Word> AllWords { get; }
        public IEnumerable<Word> RandomWords { get; }
        public Word GetWordByID(int wordID);
    }
}
