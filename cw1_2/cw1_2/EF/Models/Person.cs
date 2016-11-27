using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.EF.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string MiddleName { get; set; }

        public byte[] Photo { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
    }
}
