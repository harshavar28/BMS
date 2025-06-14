using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMSB.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("AuthCred")]
        public int AId { get; set; }
        public string Category { get; set; }

        public AuthCred AuthCred { get; set; }
        public ICollection<Approval> Approval { get; set; }

    }
}
