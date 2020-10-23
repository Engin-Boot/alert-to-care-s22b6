using DatabaseManager;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryManager.FacilityManager;
using System.Net;
using Xunit;

namespace AlertToCareTest.RepositoryTest
{
    public class FacilityManagerTest : DatabaseTest
    {
        readonly FacilityDataHandler handler;
        public FacilityManagerTest()
       : base(
           new DbContextOptionsBuilder<DatabaseContext>()
               .UseSqlite("Filename=Test.db")
               .Options)
        {
            handler = new FacilityDataHandler();
        }

        [Fact]
        public void GivenValidIcuIdThenUpdateIcuInDatabase()
        {
            using var context = new DatabaseContext(ContextOptions);

            var test = new Facility()
            {
                Id = 1,
                BedCount = 10,
                OccupiedBeds = "2,5"
            };

            var res = handler.UpdateIcu(test, context);

            Assert.True(HttpStatusCode.OK == res);
            Assert.True(test.BedCount == context.Facilities.Find(test.Id).BedCount);

        }

        [Fact]
        public void GivenInValidIcuIdThenReturnNotFound()
        {
            using var context = new DatabaseContext(ContextOptions);

            var test = new Facility()
            {
                Id = 25,
                BedCount = 10,
                OccupiedBeds = "2,5"
            };

            var res = handler.UpdateIcu(test, context);

            Assert.True(HttpStatusCode.NotFound == res);
        }

        [Fact]
        public void GivenValidIcuIdThenReturnIcuFromDatabase()
        {
            using var context = new DatabaseContext(ContextOptions);

            var res = handler.GetIcuDetailsById(2, context);

            Assert.True(res.BedCount == 8);

        }

        [Fact]
        public void GivenAddIcuthenAddEntityToDatabase()
        {
            using var context = new DatabaseContext(ContextOptions);

            var res = handler.AddNewIcu(10, context);

            Assert.True(HttpStatusCode.OK == res);
        }

        [Fact]
        public void GivenRequestGetAllThenReturnAllIcuInfo()
        {
            using var context = new DatabaseContext(ContextOptions);

            var res = handler.GetAllIcuDetails(context);

            Assert.True(res.FacilityList.Exists(f => f.BedCount == 8 && f.Id == 2));

        }


    }
}
