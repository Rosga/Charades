using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charades.Domain.Entities
{
    public class WordsInDictionary
    {
        [Key]
        public int RecordId { get; set; }
        public int WordId { get; set; }
        public int DictionaryId { get; set; }
    }
}
