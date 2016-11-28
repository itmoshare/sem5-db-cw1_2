using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.Models
{
    public class SafeReservation
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int SafeId { get; set; }
        public Safe Safe { get; set; }

        public DateTime ReservationDateStart { get; set; }

        public DateTime ReservationDateEnd { get; set; }
    }
}
