using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.Models
{
    public class SafeReservation
    {
        public int Id { get; set; }

        [Index]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        [Index]
        public int SafeId { get; set; }
        public virtual Safe Safe { get; set; }

        public DateTime ReservationDateStart { get; set; }

        public DateTime ReservationDateEnd { get; set; }
    }
}
