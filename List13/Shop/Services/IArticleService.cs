namespace Shop.Services
{
    public interface IArticleService
    {
        void IncreaseCount(int number);
        int GetArticlesCount();
        int GetPageSize();
    }
}
