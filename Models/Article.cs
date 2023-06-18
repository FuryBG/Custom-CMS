using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Type { get; set; }
        public string Keywords { get; set; }
        public string Code { get; set; }
        public string MainImageUrl { get; set; }
        public int ParentId { get; set; }
        public List<Category> Categories { get; set; }
        public List<Image> Images { get; set; }
    }
}
