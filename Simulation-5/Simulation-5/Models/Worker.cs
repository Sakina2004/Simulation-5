using Simulation_5.Models.Common;

namespace Simulation_5.Models
{
    public class Worker:BaseEntity
    {
        public string  Fullname { get; set; }
        public  string  ImagePath { get; set; }
        public  string  Description { get; set; }
        public  int PositionId { get; set; }
        public  Position Position { get; set; }
    }
}
