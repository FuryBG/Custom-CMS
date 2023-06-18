using Microsoft.EntityFrameworkCore;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CmsService
    {
        private CmsDbContext _dbContext;
        public CmsService(CmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category>? GetCategories()
        {
            return _dbContext.Category.ToList();
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _dbContext.Category.Where(c => c.CategoryId == categoryId).FirstOrDefault();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Category.Update(category);
            _dbContext.SaveChanges();
        }

        public void CreateCategory(Category category)
        {
            _dbContext.Category.Add(category);
            _dbContext.SaveChanges();
        }
    }
}
