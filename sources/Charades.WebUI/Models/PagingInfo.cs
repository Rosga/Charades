using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charades.WebUI.Models
{
    /// <summary>
    /// Модель представления страниц
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Возвратить или установить общее количество элементов
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// Возвратить или установить количество эелементов на странице
        /// </summary>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// Возвратить или установить текущий номер страницы
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Возвращает общее количество страниц
        /// </summary>
        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItems/ItemsPerPage); }
        }
    }
}