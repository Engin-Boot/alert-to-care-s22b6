using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseManager
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
      : base(options)
        { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Facility> Facilities { get; set; }
    }
}
