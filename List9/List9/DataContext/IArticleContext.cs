using List9.ViewModels;
using System;
using System.Collections.Generic;


namespace List9.DataContext
{
    public interface IArticleContext
    {
        IEnumerable<ArticleViewModel> GetArtiles();
        ArticleViewModel GetArticle(int id);
        void AddArticle(ArticleViewModel article);
        void RemoveArticle(int id);
        void UpdateArticle(int id, ArticleViewModel article);
    }
}
