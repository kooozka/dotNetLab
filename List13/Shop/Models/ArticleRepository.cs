using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Models
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyDbContext _context;
        public ArticleRepository(MyDbContext context) 
        {
            _context = context;
        }
        public Article Add(Article article)
        {
            _context.Add(article);
            _context.SaveChanges();
            return article;
        }

        public void Delete(int id)
        {
            var article = GetById(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles.ToList();
        }

        public Article GetById(int id)
        {
            return _context.Articles.Find(id);
        }

        public Article Update(Article article)
        {
            var existingArticle = _context.Articles.Find(article.Id);
            if (existingArticle != null)
            {
                existingArticle.Name = article.Name;
                existingArticle.Price = article.Price;
                existingArticle.ImageUrl = article.ImageUrl;
                existingArticle.CategoryId = article.CategoryId;
                existingArticle.Category = article.Category;
                _context.SaveChanges();
            }
            return existingArticle;
        }

        public IEnumerable<Article> GetArticles(int skip, int take) 
        {
            return _context.Articles
                .OrderBy(a => a.Id)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}
