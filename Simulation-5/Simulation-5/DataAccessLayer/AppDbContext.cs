using Microsoft.EntityFrameworkCore;
using Simulation_5.Models;

namespace Simulation_5.DataAccessLayer
{
    public class AppDbContext:DbContext
    {
        public  AppDbContext (DbContextOptions options):base(options)
        {

        }
        public  DbSet<Position> Positions { get; set; }
        public  DbSet<Worker> Workers { get; set; }
    }
    
}
