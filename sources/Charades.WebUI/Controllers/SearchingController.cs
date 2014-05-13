using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Charades.Domain.Abstract;
using Charades.Domain.Entities;
using Microsoft.SqlServer.Server;

namespace Charades.WebUI.Controllers
{
    public class SearchingController : Controller
    {
        private ICharadeRepository _repository;

        public SearchingController(ICharadeRepository repository)
        {
            _repository = repository;
        }
        //
        // GET: /Search/
        public PartialViewResult Search()
        {
            return PartialView();
        }

        public JsonResult GetWords(string term)
        {
            

            var words = _repository.Words.Where(w => term == "" || w.Name.Contains(term))
                .Select(w=> new {w.WordId, value = w.Name,}).ToList();

            return Json(words, JsonRequestBehavior.AllowGet);
        }
    }
}