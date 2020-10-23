using AlertToCare.Controllers;
using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryManager.VitalManager;
using Xunit;

namespace AlertToCareTest.ControllerTest
{
    public class VitalsControllerTest : DatabaseTest
    {
        readonly VitalsController controller;
        public VitalsControllerTest()
           : base(
               new DbContextOptionsBuilder<DatabaseContext>()
                   .UseSqlite("Filename=Test.db")
                   .Options)
        {
            controller = new VitalsController
                (new DatabaseContext(ContextOptions), new VitalDataHandler());
        }

        [Fact]
        public void GivenVitalModelThenReturnVitalStatusModel()
        {
            var test = new VitalModel()
            {
                IcuId = 1,
                BedId = 2,
                Vitals = new Vitals
                {
                    Bpm = 120,
                    Spo2 = 100,
                    RespRate = 60
                }
            };

            var res = controller.MonitorVitals(test);
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public void GivenVitalModelWithBadIdsThenReturnForbiddenStatus()
        {
            var test = new VitalModel()
            {
                IcuId = 120,
                BedId = 1000,
                Vitals = new Vitals
                {
                    Bpm = 120,
                    Spo2 = 100,
                    RespRate = 60
                }
            };

            var res = controller.MonitorVitals(test);
            Assert.IsType<OkObjectResult>(res);

        }

        [Fact]
        public void GivenVitalModelWithUnOcuupiedBedIdsThenReturnForbiddenStatus()
        {
            var test = new VitalModel()
            {
                IcuId = 1,
                BedId = 1,
                Vitals = new Vitals
                {
                    Bpm = 120,
                    Spo2 = 100,
                    RespRate = 60
                }
            };

            var res = controller.MonitorVitals(test);
            Assert.IsType<OkObjectResult>(res);

        }

    }
}
