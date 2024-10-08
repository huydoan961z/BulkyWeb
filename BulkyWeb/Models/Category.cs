using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key] // Data annotation for primary key
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")] // Data annotation for display name
        //[MaxLength(10)] // Uncomment this if you want to limit the length
        public string Name { get; set; }

        [Required]
        [Display(Name = "Display Order")] // Data annotation for display name
        //[Range(1, 10)] // Uncomment this to add a range constraint
        public int DisplayOrder { get; set; }
    }
}
