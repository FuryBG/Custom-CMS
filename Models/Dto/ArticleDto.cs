using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Models.Dto
{
    public class ArticleDto: Article
    {
        public ArticleDto()
        {
            AddedCategories = new List<Category>();
            Categories = new List<Category>();
            AvailableCategoriesList = new List<SelectListItem>();
        }
        public List<Category> AddedCategories { get; set; }
        public List<SelectListItem> AvailableCategoriesList { get; set; }
        public string AddedCategory { get; set; }
    }
}
