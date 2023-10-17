using System.ComponentModel.DataAnnotations;

namespace EFCoreUTC.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string Memo { get; set; } = null!;
        [Required]
        public DateTime ExecutionDate { get; set; }
    }
}
