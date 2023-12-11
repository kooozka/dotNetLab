using List9.DataContext;
using List9.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace List9.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleContext _articleContext;

        public ArticleController(IArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }



        // GET: ArticleController
        public ActionResult Index()
        {
            return View(_articleContext.GetArtiles());
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            return View(_articleContext.GetArticle(id));
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleViewModel article)
        {
            try
            {
                if (ModelState.IsValid)
                    _articleContext.AddArticle(article);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_articleContext.GetArticle(id));
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleViewModel article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    article.Id = id;
                    _articleContext.UpdateArticle(article);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articleContext.GetArticle(id));
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _articleContext.RemoveArticle(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
