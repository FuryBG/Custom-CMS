using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Models.Dto
{
    public class ArticleDto: Article
    {
        public ArticleDto()
        {
            Categories = new List<Category>();
            AvailableCategoriesList = new List<SelectListItem>();
        }
        public List<SelectListItem> AvailableCategoriesList { get; set; }
        public string AddedCategory { get; set; }
        public string AddedImage { get; set; }

        public static ArticleDto ToArticleDto(Article article)
        {
            return new ArticleDto()
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                Categories = article.Categories,
                Code = article.Code,
                Images = article.Images,
                Keywords = article.Keywords,
                Type = article.Type,
                UserId = article.UserId,
            };
        }

        public static Article ToArticle(ArticleDto articleDto, Article article)
        {
            article.Title = articleDto.Title;
            article.Description = articleDto.Description;
            article.Code = articleDto.Code;
            article.Keywords = articleDto.Keywords;
            article.Type = articleDto.Type;
            article.UserId = articleDto.UserId;
            return article;
        }
    }
}
