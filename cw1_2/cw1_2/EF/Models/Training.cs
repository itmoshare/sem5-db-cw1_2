using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.EF.Models
{
    public partial class Training
    {
        public int Id { get; set; }

        [Index]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [Index]
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [Index]
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public virtual TrainingProgram TrainingProgram { get; set; }

        public TimeSpan TimeBegin { get; set; }

        public TimeSpan TimeEnd { get; set; }

        [StringLength(50)]
        public string Days { get; set; }

        [Index]
        public List<Client> Clients { get; set; }
    }
}
