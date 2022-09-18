using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBooks.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Cover Type Name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
