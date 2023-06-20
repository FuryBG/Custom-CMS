using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Category : BaseCms
    {
        public string? MainImageUrl { get; set; }
        public int? ParentId { get; set; }
        public List<Article>? Articles { get; set; }
        public List<Image>? Images { get; set; }
        public List<Category>? SubCategories { get; set; }
        public virtual Category? Parent { get; set; }
    }
}
