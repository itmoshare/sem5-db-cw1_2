using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw1_2.Models;

namespace cw1_2.Model
{
    public class TrainningClientRelation
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
