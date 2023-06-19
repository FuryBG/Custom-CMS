using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Category : BaseCms
    {
        public string MainImageUrl { get; set; }
        public List<Article> Articles { get; set; }
        public List<Image> Images { get; set; }
    }
}
