using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using Charades.Domain.Abstract;
using Charades.Domain.Entities;

namespace Charades.WebUI.Controllers
{
    public class NavController : Controller
    {
        //Хранилище
        private ICharadeRepository _repository;

        /// <summary>
        /// Создает новый контроллер MenuController
        /// </summary>
        /// <param name="repository">Хранилище объекта Charades</param>
        public NavController(ICharadeRepository repository)
        {
            _repository = repository;
        }
        public PartialViewResult Menu(int id = 0)
        {
            var levels = _repository.Levels.ToList();
            var level = levels.Where(l => l.LevelId == id).Select(l => l.Description);
            var name = "";
            foreach (var l in level)
            {
                name = l;
                break;
            }

            ViewBag.Selectedlevel = name;

            return PartialView(levels);
        }
	}
}