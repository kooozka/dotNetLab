using List9.ViewModels;
using System.Collections.Generic;

namespace List9.DataContext
{
    public class ListArticleContext : IArticleContext
    {
        public void AddArticle(ArticleViewModel article)
        {
            throw new System.NotImplementedException();
        }

        public ArticleViewModel GetArticle(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ArticleViewModel> GetArtiles()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveArticle(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateArticle(int id, ArticleViewModel article)
        {
            throw new System.NotImplementedException();
        }
    }
}
