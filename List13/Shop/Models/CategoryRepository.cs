using Shop.Data;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;
        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category Update(Category category)
        {
            var existingCategory = _context.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _context.SaveChanges();
            }
            return existingCategory;
        }
    }
}
