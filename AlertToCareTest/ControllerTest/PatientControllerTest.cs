using AlertToCare.Controllers;
using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryManager.PatientManager;
using System.Net;
using Xunit;

namespace AlertToCareTest.ControllerTest
{
    public class PatientControllerTest : DatabaseTest
    {
        readonly PatientController controller;
        public PatientControllerTest()
           : base(
               new DbContextOptionsBuilder<DatabaseContext>()
                   .UseSqlite("Filename=Test.db")
                   .Options)
        {
            controller = new PatientController
                (new DatabaseContext(ContextOptions), new PatientDataHandler());
        }

        [Fact]
        public void GivenPatientInfoThenAddNewPatientToDatabaseAndReturnOk()
        {
            var test = new Patient()
            {
                Name = "Subject Z",
                Contact = "1111777790",
                IcuId = 2,
                BedId = 1
            };
            var res = controller.AddPatient(test);
            Assert.True(res == HttpStatusCode.OK);
        }

        [Fact]
        public void GivenPatientIdThenRemoveFromDatabaseReturnOk()
        {
            var res = controller.DishchargePatient("3");
            Assert.True(res == HttpStatusCode.OK);
        }

        [Fact]
        public void WhenPatientInfoRequestedByIdThenReturnPatientDetails()
        {
            var res = controller.GetPatientDetailsById("1");
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public void WhenAllPatientInfoRequestedThenReturnAllPatientDetails()
        {
            var res = controller.GetAllPatientDetails();
            Assert.IsType<OkObjectResult>(res);
        }


    }
}
