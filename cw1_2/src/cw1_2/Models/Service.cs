using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Index]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
