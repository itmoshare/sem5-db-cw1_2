using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using cw1_2.Model;

namespace cw1_2.Models
{
    public class Client
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public List<TrainningClientRelation> Trainnings;
    }
}
