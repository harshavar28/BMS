using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BMSB.Models
{
    public class Approval
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BId { get; set; }

        [ForeignKey("Cred")]
        public int UId { get; set; }
        public string? Status { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        [JsonIgnore]
        public Cred Cred { get; set; }
    }
}
