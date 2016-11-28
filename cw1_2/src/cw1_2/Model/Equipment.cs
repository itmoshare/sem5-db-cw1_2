using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public DateTime IncomeDate { get; set; }
    }
}
