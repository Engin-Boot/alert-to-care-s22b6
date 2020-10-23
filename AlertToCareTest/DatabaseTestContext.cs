using DatabaseManager;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AlertToCareTest
{
    public class DatabaseTest
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        protected DatabaseTest(DbContextOptions<DatabaseContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<DatabaseContext> ContextOptions { get; }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using var _context = new DatabaseContext(ContextOptions);
                    {
                        _context.Database.EnsureDeleted();
                        _context.Database.EnsureCreated();

                        var onep = new Patient()
                        {
                            Id = 1,
                            Name = "Subject 1",
                            Contact = "1111777788",
                            IcuId = 1,
                            BedId = 2
                        };

                        var twop = new Patient()
                        {
                            Id = 2,
                            Name = "Subject 2",
                            Contact = "1111777789",
                            IcuId = 1,
                            BedId = 5
                        };

                        var threep = new Patient()
                        {
                            Id = 3,
                            Name = "Subject 3",
                            Contact = "1111777790",
                            IcuId = 2,
                            BedId = 3
                        };

                        var fourp = new Patient()
                        {
                            Id = 4,
                            Name = "Subject 4",
                            Contact = "1111777710",
                            IcuId = 2,
                            BedId = 2
                        };

                        var onef = new Facility()
                        {
                            Id = 1,
                            BedCount = 5,
                            OccupiedBeds = "2,5"
                        };

                        var twof = new Facility()
                        {
                            Id = 2,
                            BedCount = 8,
                            OccupiedBeds = "3"
                        };

                        _context.Patients.AddRange(onep, twop, threep, fourp);
                        _context.Facilities.AddRange(onef, twof);

                        _context.SaveChanges();
                    }
                    _databaseInitialized = true;
                }
            }
        }
    }
}
