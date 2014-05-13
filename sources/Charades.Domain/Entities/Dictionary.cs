using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charades.Domain.Entities
{
    //Модель таблицы Dictionaries
    public class Dictionary
    {
        public int DictionaryId { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
