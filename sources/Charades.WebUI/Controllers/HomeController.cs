using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Charades.Domain.Abstract;
using Charades.Domain.Entities;
using Charades.WebUI.HtmlHelpers;
using Charades.WebUI.Models;

namespace Charades.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //Хранилище
        private ICharadeRepository _repository;

        //Колличество записей на странице
        public int PageSize = 3;

        /// <summary>
        /// Создать новый объект контроллера
        /// </summary>
        /// <param name="charadeRepository">Хранилище, передаваимое в контроллер</param>
        public HomeController(ICharadeRepository charadeRepository)
        {
            _repository = charadeRepository;
        }

        //[ActionName("Defualt")]
        public ViewResult Index(string navType = "", int id = 0, int page = 1)
        {
            WordsListViewModel viewModel = null;
            switch (navType)
            {
                case "":
                    viewModel = new WordsListViewModel
                    {
                        Words = _repository.Words
                            .OrderBy(w => w.WordId)
                            .Skip((page - 1) * PageSize).Take(PageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = _repository.Words.Count()
                        }
                    };
                    break;
                case "Level":
                    viewModel = new WordsListViewModel
                    {
                        Words = _repository.Words
                            .Where(w => id == 0 || w.LevelId == id)
                            .OrderBy(w => w.WordId)
                            .Skip((page - 1) * PageSize).Take(PageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = id == 0 ? _repository.Words.Count() :
                                _repository.Words.Count(l => l.LevelId == id)
                        },
                        Level = _repository.Levels.FirstOrDefault(l => l.LevelId == id),
                        NavType = navType
                    };
                    break;
                case "Dict":
                    viewModel = new WordsListViewModel
                    {
                        Words = (from word in _repository.Words
                            join wordsInDictionary in _repository.WordsInDictionaries on word.WordId equals wordsInDictionary.WordId
                                 where wordsInDictionary.DictionaryId == id
                                 select word).AsQueryable().OrderBy(w => w.LevelId).Skip((page - 1) * PageSize).Take(PageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = id == 0 ? _repository.Words.Count() :
                                _repository.WordsInDictionaries.Count(w => w.DictionaryId == id)
                        },
                        Dictionary = _repository.Dictionaries.FirstOrDefault(l => l.DictionaryId == id),
                        NavType = navType
                    };
                    break;
            }

            //ViewBag.Words = viewModel.Words;
            return View(viewModel);
        }

        public ViewResult Index1(WordsListViewModel model)
        {
            
            //ViewBag.Words = viewModel.Words;
            return View("Index",model);
        }
        //public ViewResult Index(int wordId, string word);

        /// <summary>
        /// Возварщает на скачивание .txt файл со словами заданого уровня или словаря
        /// </summary>
        /// <param name="level">код уровня слов</param>
        /// <returns>.txt файл</returns>
        public ActionResult GetFile(int level = 0)
        {
            var words = _repository.Words
                .Where(w => level == 0 || w.LevelId == level);
            var wordString = Enumerable.Aggregate(words, "", (current, word) => current + string.Format("{0}, ", word.Name));

            return File(Encoding.UTF8.GetBytes(wordString), "text/plain",
                string.Format("{0}_words_for_Charades.txt", level == 0 ? "All" : level.ToString()));
        }

        /// <summary>
        /// Добавляет слово в словарь пользователя
        /// </summary>
        /// <param name="wordId">ID слова</param>
        /// <param name="dictId">ID словаря</param>
        /// <returns>пустое значение</returns>
        public EmptyResult AddWord(int wordId, int dictId)
        {
            _repository.AddWordInDictionary(wordId, dictId);

            return new EmptyResult();
        }

        public string GetHtmlFromView(List<Word> words, int page = 1)
        {
            var viewModel = new WordsListViewModel()
            {
                Words = words.OrderBy(w => w.WordId).Skip((page - 1)*PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = words.Count()
                },
                NavType = "Seaching"
          };
            var str = ViewToStringHelper.RenderViewToString(this.ControllerContext, "Index", viewModel);

            return str;
        }

        public ActionResult RefreshWords(string jsonWords, string path)
        {
            var serializer = new JavaScriptSerializer();
            var words = serializer.Deserialize<List<Word>>(jsonWords);
            var str = GetHtmlFromView(words);

            return Content(str);
        }

        public ActionResult Searchable(string term = "", int page = 1)
        {
            var viewModel = new WordsListViewModel()
            {
                Words = _repository.Words.Where(w => term == "" || w.Name.Contains(term)).OrderBy(w => w.WordId)
                    .Skip((page - 1)*PageSize).Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Words.Count(w => term == "" || w.Name.Contains(term))
                },
                NavType = "Searching",
            };

            var str = ViewToStringHelper.RenderViewToString(this.ControllerContext, "Index", viewModel);

            return Content(str);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
