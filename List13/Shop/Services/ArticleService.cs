namespace Shop.Services
{
    public class ArticleService : IArticleService
    {
        private int articlesCount;
        private int pageSize;

        public ArticleService()
        {
            articlesCount = 6;
            pageSize = 4;
        }

        public int GetArticlesCount()
        {
            return articlesCount;
        }

        public int GetPageSize()
        {
            return pageSize;
        }

        public void IncreaseCount(int number)
        {
            articlesCount += number;
        }
    }
}
