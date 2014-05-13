using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charades.Domain.Entities
{
    //Модель таблицы Levels
    public class Level
    {
        public int LevelId { get; set; }

        public string Description { get; set; }
    }
}
