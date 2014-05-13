using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charades.Domain.Entities
{
    //Модель таблицы Words
    public class Word
    {
        public int WordId { get; set; }
        public string Name { get; set; }
        public int LevelId { get; set; }
    }
}
