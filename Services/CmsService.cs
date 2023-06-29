﻿using Microsoft.EntityFrameworkCore;
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
            List<Category> categories = _dbContext.Category
                .Where(c => c.ParentId == null)
                .Include(c => c.Articles)
                .Include(c => c.Images)
                .Include(c => c.SubCategories)
                .ThenInclude(sc => sc.SubCategories)
                .Include(c => c.SubCategories)
                .ThenInclude(sc => sc.Articles)
                .Include(c => c.SubCategories)
                .ThenInclude(sc => sc.Images)
                .Include(c => c.SubCategories)
                .ThenInclude(sc => sc.SubCategories)
                .ThenInclude(scc => scc.Articles)
                .Include(c => c.SubCategories)
                .ThenInclude(sc => sc.SubCategories)
                .ThenInclude(ssc => ssc.Images).ToList();
            
            return categories;
        }

        public List<Category> GetChildren(int? id)
        {
            List<Category> result = _dbContext.Category.Where(x => x.ParentId == id).Include(c => c.Articles).Include(c => c.Images).ToList<Category>();
            foreach (var item in result)
            {
                item.SubCategories = GetChildren(item.Id);
            }
            return result;
        }

        public List<Article>? GetArticles()
        {
            return _dbContext.Article.ToList();
        }

        public List<Image>? GetImages()
        {
            return _dbContext.Image.ToList();
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _dbContext.Category.Where(c => c.Id == categoryId).FirstOrDefault();
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

        public PageModel GetPageData()
        {
            PageModel pageModel = new PageModel();
            pageModel.Categories = GetCategories();
            pageModel.Articles = GetArticles();
            pageModel.Images = GetImages();
            return pageModel;
        }
    }
}
