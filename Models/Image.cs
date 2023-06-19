using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Image : BaseCms
    {
        public string Url { get; set; }
        public List<Category> Categories { get; set; }
    }
}
