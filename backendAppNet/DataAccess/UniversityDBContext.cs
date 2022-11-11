using backendAppNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace backendAppNet.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options) 
        {
        
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Courses>? Courses { get; set; }
    }
}
