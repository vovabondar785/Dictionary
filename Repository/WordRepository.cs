using Dictionary.Interfaces;
using Dictionary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Repository
{
    public class WordRepository : IWords
    {
        private readonly AppDBContent dbContent;

        public WordRepository(AppDBContent dbContent)
        {
            this.dbContent = dbContent;
        }

        public IEnumerable<Word> AllWords => dbContent.Words;
        public IEnumerable<Word> RandomWords { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddWord(Word word)
        {
            dbContent.Add(word);
        }

        public Word GetWordByID(int wordID) => dbContent.Words.Where(w => w.ID == wordID).FirstOrDefault();
    }
}
