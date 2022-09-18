using System.ComponentModel.DataAnnotations;

namespace UBooks.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display Order Must be within 1 an 100 !")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
