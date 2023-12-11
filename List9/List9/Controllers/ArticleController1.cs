using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace List9.Controllers
{
    public class ArticleController1 : Controller
    {
        // GET: ArticleController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArticleController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticleController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticleController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticleController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
