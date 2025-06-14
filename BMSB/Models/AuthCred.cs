using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BMSB.Models
{
    public class AuthCred
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [JsonIgnore]
        public string Password { get; set; }
        
        public string? Approval  { get; set; }
        [JsonIgnore]
        public ICollection<Book> Book { get; set; }
    }
}
