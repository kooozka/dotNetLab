using List10.Data;
using List10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace List10.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;

        public ShopController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var articles = await _context.Articles.ToListAsync();

            var viewModel = new ShopViewModel
            {
                Categories = categories,
                Articles = articles,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ArticlesByCategory(int categoryId)
        {
            if (categoryId == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var category = await _context.Categories.FindAsync(categoryId);
            var allCategories = await _context.Categories.ToListAsync();

            if (category == null)
            {
                return NotFound();
            }
            var articles = await _context.Articles
                .Where(a => a.CategoryId == categoryId)
                .Include(a => a.Category)
                .ToListAsync();

            var viewModel = new ShopViewModel
            {
                Categories = allCategories,
                Articles = articles,
            };
            return View(viewModel);
        }

        public IActionResult AddToCart(int articleId) 
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);

            var cookieKey = "article" + articleId;
            var articleCount = 0;
            bool successful = int.TryParse(Request.Cookies[cookieKey], out articleCount);
            articleCount = successful ? articleCount + 1 : 1;

            Response.Cookies.Append(cookieKey, articleCount.ToString(), option);
            return RedirectToAction(nameof(ArticlesByCategory));
        }
    }
}
