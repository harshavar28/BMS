using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BMSB.Models
{
    public class Cred
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [MinLength(3)]
        public string Uname { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public ICollection<Approval> Approvals { get; set; }
    }
}
