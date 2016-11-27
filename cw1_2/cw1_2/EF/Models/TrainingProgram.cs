using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cw1_2.EF.Models
{
    public class TrainingProgram
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string Program { get; set; }
    }
}
