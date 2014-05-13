using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charades.Domain.Entities;

namespace Charades.Domain.Concrete
{
    //Контекст базы данных
    public class EFDbContext : DbContext
    {
        //таблица Words
        public DbSet<Word> Words { get; set; }

        //таблица Dictionaries
        public DbSet<Dictionary> Dictionaries { get; set; }

        //таблица Levels
        public DbSet<Level> Levels { get; set; }

        public DbSet<WordsInDictionary> WordsInDictionaries { get; set; }
    }
}
