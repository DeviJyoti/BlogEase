using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace BlogEase.Models
{
    
    public class ContentClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MinLength(1)]
        [MaxLength(2500)]
        [Required]
        public string Content { get; set; }
    }
}
