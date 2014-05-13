using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charades.Domain.Abstract;
using Charades.Domain.Entities;

namespace Charades.Domain.Concrete
{
    //хранилище базы данных
    public class EFCharadesRepository : ICharadeRepository
    {
        private readonly EFDbContext _context = new EFDbContext();
        //таблица Words
        public IQueryable<Word> Words {
            get { return _context.Words; } }

        //Таблица Dictionaries
        public IQueryable<Dictionary> Dictionaries { get { return _context.Dictionaries; } }
        //Таблица Levels
        public IQueryable<Level> Levels {
            get { return _context.Levels; }
        }
        /// <summary>
        /// таблица WordsInDictionaries
        /// </summary>
        public IQueryable<WordsInDictionary> WordsInDictionaries
        {
            get { return _context.WordsInDictionaries; }
        } 

        //-------------------------------------------------------------------------------------

        public void AddWordInDictionary(int wordId, int dictId)
        {
            var wid = new WordsInDictionary()
            {
                WordId = wordId,
                DictionaryId = dictId
            };
            _context.WordsInDictionaries.Add(wid);
            _context.SaveChanges();
        }

        public void AddNewDictionary(Dictionary dictionary)
        {
            _context.Dictionaries.Add(dictionary);
            _context.SaveChanges();
            //_context.SaveChangesAsync();
        }
    }
}
