using Shop.Data;
using Shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext _context;
        public CartController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Article> articles = await _context.Articles.ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
            List<int> articlesIds = articles.Select(a => a.Id).ToList();
            Dictionary<Article, int> articlesCounts = new Dictionary<Article, int>();
            double value = 0;
            foreach (int articleId in articlesIds)
            {
                string cookieKey = $"article{articleId}";
                string cookieValue = Request.Cookies[cookieKey];
                Article article = await _context.Articles.FindAsync(articleId);

                if (int.TryParse(cookieValue, out int count))
                {
                    articlesCounts[article] = count;
                }
                value += count * article.Price;
            }
            var viewModel = new CartViewModel
            {
                Articles = articlesCounts,
                Categories = categories,
                CartValue = Math.Round(value, 2)
            };
            return View(viewModel);
        }

        public IActionResult IncreaseCount(int articleId)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);

            string cookieKey = $"article{articleId}";
            string cookieValue = Request.Cookies[cookieKey];
            if (int.TryParse(cookieValue, out int count))
            {
                count++;
            }
            Response.Cookies.Append(cookieKey, count.ToString(), option);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DecreaseCount(int articleId)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);

            string cookieKey = $"article{articleId}";
            string cookieValue = Request.Cookies[cookieKey];
            if (int.TryParse(cookieValue, out int count))
            { 
                count--;
            }
            Response.Cookies.Delete(cookieKey);
            if (count > 0)
            {
                Response.Cookies.Append(cookieKey, count.ToString(), option);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
