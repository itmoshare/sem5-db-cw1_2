using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw1_2.EF.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Index]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        [Index]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
