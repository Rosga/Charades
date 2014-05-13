using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Charades.Domain.Entities;

namespace Charades.Domain.Abstract
{
    //интерфейс хранилища базы данных
    public interface ICharadeRepository
    {
        //таблица Words
        IQueryable<Word> Words { get; }
        //таблица Levels
        IQueryable<Level> Levels { get; }
        //таблица Dictionaries
        IQueryable<Dictionary> Dictionaries { get; }
        //таблица WordsInDictionaries
        IQueryable<WordsInDictionary> WordsInDictionaries { get; }

        //-----------------------------------------------------------------------
        void AddNewDictionary(Dictionary dictionary);
        void AddWordInDictionary(int wordId, int dictId);
    }
}
