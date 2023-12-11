using List9.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace List9.DataContext
{
    public class ListArticlesContext : IArticleContext
    {
        List<ArticleViewModel> articles = new List<ArticleViewModel>()
        {
            new ArticleViewModel(0, "naturalYogurt", 2.99, new DateTime(2024, 1, 10), Category.Dairy),
            new ArticleViewModel(1, "milkChocolate", 4.49, new DateTime(2024, 10, 25), Category.Sweets),
            new ArticleViewModel(2, "Lemon", 5.99, new DateTime(2025, 1, 1), Category.Fruits)
        };
        public void AddArticle(ArticleViewModel article)
        {
            int nextNumber = articles.Max(a => a.Id) + 1;
            article.Id = nextNumber;
            articles.Add(article);
        }

        public ArticleViewModel GetArticle(int id)
        {
            return articles.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<ArticleViewModel> GetArtiles()
        {
            return articles;
        }

        public void RemoveArticle(int id)
        {
            ArticleViewModel articleToRemove = articles.FirstOrDefault(a => a.Id == id);
            if (articleToRemove != null)
            {
                articles.Remove(articleToRemove);
            }
        }

        public void UpdateArticle(ArticleViewModel article)
        {
            ArticleViewModel articleToUpdate = articles.FirstOrDefault(a => a.Id == article.Id);
            articles = articles.Select(a => (a.Id == article.Id) ? article : a).ToList();
        }
    }

    public class DictionaryArticlesContext : IArticleContext
    {
        private int currentId = 3;
        private Dictionary<int, ArticleViewModel> articles = new Dictionary<int, ArticleViewModel>()
        {
            {0, new ArticleViewModel("naturalYogurt", 2.99, new DateTime(2024, 1, 10), Category.Dairy) },
            {1, new ArticleViewModel("milkChocolate", 4.49, new DateTime(2024, 10, 25), Category.Sweets)},
            {2, new ArticleViewModel("Lemon", 5.99, new DateTime(2025, 1, 1), Category.Fruits) }
        };
        public void AddArticle(ArticleViewModel article)
        {
            //int nextNumber = articles.Count;
            articles.Add(currentId, article);
            currentId++;
        }

        public ArticleViewModel GetArticle(int id)
        {
            articles.TryGetValue(id, out var article);
            return article;
        }

        public IEnumerable<ArticleViewModel> GetArtiles()
        {
            return articles.Select(a => new ArticleViewModel(a.Key, a.Value.Name, a.Value.Price, a.Value.ExpiryDate, a.Value.Category));
        }

        public void RemoveArticle(int id)
        {
            articles.Remove(id);
        }

        public void UpdateArticle(ArticleViewModel article)
        {
            if (articles.ContainsKey(article.Id))
            {
                articles[article.Id] = article;
            };
        }
    }
}
