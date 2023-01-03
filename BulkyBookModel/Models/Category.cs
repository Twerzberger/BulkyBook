using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        [DisplayName("Create Date Time")]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
