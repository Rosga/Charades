using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Charades.Domain.Abstract;
using Charades.Domain.Entities;
using Microsoft.Ajax.Utilities;

namespace Charades.WebUI.Controllers
{
    /// <summary>
    /// Контроллер навигации по словарям пользователя
    /// </summary>
    public class DictionariesController : Controller
    {
        private readonly ICharadeRepository _repository;

        /// <summary>
        /// Создает новый контроллер DictionariesController
        /// </summary>
        /// <param name="repository">Хранилище объекта Charades</param>
        public DictionariesController(ICharadeRepository repository)
        {
            _repository = repository;
        }


        public PartialViewResult DictionaryNav()
        {
            var name = this.User.Identity.Name;
            IEnumerable<Dictionary> dictionaries =
                _repository.Dictionaries.Where(
                    d => name == null || d.UserName == name);

            return PartialView(dictionaries);
        }

        public ActionResult AddDictionary(string name)
        {
            var membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                var dictionary = new Dictionary {Name = name, UserName = membershipUser.UserName};
                _repository.AddNewDictionary(dictionary);
            }
            //name = this.User.Identity.Name;
            IEnumerable<Dictionary> dictionaries =
                _repository.Dictionaries.Where(
                    d => d.UserName == membershipUser.UserName);

            //_repository.Dictionaries.
            return PartialView("DictionaryNav", dictionaries);
        }
    }
}