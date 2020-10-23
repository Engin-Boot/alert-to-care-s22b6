using AlertToCare.Controllers;
using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryManager.FacilityManager;
using System.Net;
using Xunit;

namespace AlertToCareTest.ControllerTest
{
    public class AdminControllerTest : DatabaseTest
    {
        readonly AdminController controller;
        public AdminControllerTest()
           : base(
               new DbContextOptionsBuilder<DatabaseContext>()
                   .UseSqlite("Filename=Test.db")
                   .Options)
        {
            controller = new AdminController
                (new DatabaseContext(ContextOptions), new FacilityDataHandler());
        }

        [Fact]
        public void GivenBedCountThenAddNewIcuToDatabase()
        {
            var res = controller.AddIcu("15");
            Assert.True(res == HttpStatusCode.OK);
        }

        [Fact]
        public void GivenUpdateRequestThenUpdateExistingIcuInDatabase()
        {
            var test = new Facility()
            {
                Id = 2,
                BedCount = 20,
                OccupiedBeds = "3"
            };
            var res = controller.UpdateIcuData(test);
            Assert.True(res == HttpStatusCode.OK);
        }

        [Fact]
        public void WhenIcuInfoRequestedByIdThenReturnIcuDetails()
        {
            var res = controller.GetIcuDetailsById("1");
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public void WhenAllIcuInfoRequestedThenReturnAllIcuDetails()
        {
            var res = controller.GetAllIcuDetails();
            Assert.IsType<OkObjectResult>(res);
        }


    }
}
