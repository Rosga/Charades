using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Charades.Domain.Entities;

namespace Charades.WebUI.Models
{
    /// <summary>
    /// Модель представления слов на странице
    /// </summary>
    public class WordsListViewModel
    {
        /// <summary>
        /// Перечисление слов
        /// </summary>
        public IEnumerable<Word> Words { get; set; }
        /// <summary>
        /// Модель страницы
        /// </summary>
        public PagingInfo PagingInfo { get; set; }

        /// <summary>
        /// Перечесление уровней
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// перечисление словарей
        /// </summary>
        public Dictionary Dictionary { get; set; }

        public string NavType { get; set; }
        public string Term { get; set; }
    }
}