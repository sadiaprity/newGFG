using System.ComponentModel.DataAnnotations;

namespace evaluation2.Models
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Area { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
