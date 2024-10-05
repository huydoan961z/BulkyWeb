using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        
        [Key] // data anotation
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")] // data anotation
		[MaxLength(50)]// data anotation
		[MinLength(3)]

		public string Name { get; set; } 
        [Required]
		[Display(Name = "Display Order")] // data anotation
		public int DisplayOrder { get; set; }
        public Category()
        {
            
        }
    }
}
