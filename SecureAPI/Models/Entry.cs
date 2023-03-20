using System.ComponentModel.DataAnnotations;

namespace SecureAPI.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(20)]
        public float Distance { get; set; }
        [MaxLength(50)]
        public float Time { get; set; } 
        public Guid UserId { get; set; }
    }
}
