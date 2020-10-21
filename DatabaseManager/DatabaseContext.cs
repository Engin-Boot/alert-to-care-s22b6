using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.IO;

namespace DatabaseManager
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
      : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
             options.UseSqlite(
                $"Data source = {FileNameConfig()}",
                optionsBuilder =>
                        optionsBuilder.MigrationsAssembly(
                            typeof(DatabaseContext).Namespace)
                );
            base.OnConfiguring(options);
        }

        private static string FileNameConfig() =>
         Path.Combine(Environment.CurrentDirectory, "AlertToCare.db");
    }
}




