using Simulation_5.Models.Common;

namespace Simulation_5.Models
{
    public class Position:BaseEntity
    {
        public  int Id { get; set; }
        public  string  fullname { get; set; }
        public  IEnumerable<Position> Positions { get; set; }
    }
}
