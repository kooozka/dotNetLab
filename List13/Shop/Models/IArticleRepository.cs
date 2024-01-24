using System.Collections;
using System.Collections.Generic;

namespace Shop.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        Article Add(Article article);
        Article Update(Article article);
        void Delete(int id);
        IEnumerable<Article> GetArticles(int skip, int take);
    }
}
