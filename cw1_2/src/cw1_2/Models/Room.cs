using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cw1_2.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public TimeSpan WorkTimeBegin { get; set; }

        public TimeSpan WorkTimeEnd { get; set; }
    }
}
