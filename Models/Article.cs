using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Article : BaseCms
    {
        public string MainImageUrl { get; set; }
        public List<Category> Categories { get; set; }
        public List<Image> Images { get; set; }
    }
}
