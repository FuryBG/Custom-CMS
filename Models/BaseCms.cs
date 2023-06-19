using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class BaseCms
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Type { get; set; }
        public string Keywords { get; set; }
        public string Code { get; set; }
        public int ParentId { get; set; }
    }
}
