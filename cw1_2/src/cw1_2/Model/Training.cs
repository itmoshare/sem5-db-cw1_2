using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.Models
{
    public partial class Training
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public TrainingProgram TrainingProgram { get; set; }

        public TimeSpan TimeBegin { get; set; }

        public TimeSpan TimeEnd { get; set; }

        [StringLength(50)]
        public string Days { get; set; }
    }
}
