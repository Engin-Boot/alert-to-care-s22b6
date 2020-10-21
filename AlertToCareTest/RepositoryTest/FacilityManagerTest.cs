using DatabaseManager;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AlertToCareTest.RepositoryTest
{
    public class FacilityManagerTest : DatabaseTestContext
    {
        public FacilityManagerTest()
       : base(
           new DbContextOptionsBuilder<DatabaseContext>()
               .UseSqlite("Filename=Test.db")
               .Options)
        {

        }

        [Fact]
        public void Test1()
        {

        }
    }
}
