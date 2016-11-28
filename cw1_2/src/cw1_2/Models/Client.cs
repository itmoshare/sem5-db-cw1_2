using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.Models
{
    public class Client
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        [Index]
        public List<Training> Trainings { get; set; }
    }
}
