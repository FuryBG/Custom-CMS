namespace WebApplication1.Models
{
    public class PageModel
    {
        public List<Category> Categories { get; set; }
        public List<Article> Articles { get; set; }
        public List<Image> Images { get; set; }
        public Category SelectedCategory { get; set; }
        public Article SelectedArticle { get; set; }
        public Image SelectedImage { get; set; }
    }
}
