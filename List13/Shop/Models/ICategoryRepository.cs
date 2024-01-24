using System.Collections.Generic;

namespace Shop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category Add(Category article);
        Category Update(Category article);
        void Delete(int id);
    }
}
