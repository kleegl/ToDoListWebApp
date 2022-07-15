using System.ComponentModel.DataAnnotations;

namespace ToDoListWebApp.Models
{
    public class Note
    {
        [Key] [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Record { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
