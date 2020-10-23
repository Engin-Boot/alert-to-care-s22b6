using DatabaseManager;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryManager.VitalManager;
using Xunit;

namespace AlertToCareTest.RepositoryTest
{
    public class VitalManagerTest : DatabaseTest
    {
        readonly VitalDataHandler handler;
        public VitalManagerTest()
       : base(
           new DbContextOptionsBuilder<DatabaseContext>()
               .UseSqlite("Filename=Test.db")
               .Options)
        {
            handler = new VitalDataHandler();
        }

        [Fact]
        public void GivenNormalVitalInfoThenReturnVitalStatusNormal()
        {
            using var context = new DatabaseContext(ContextOptions);

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

            var res = handler.MonitorVitals(test, context);

            Assert.True(res.Bpm == "Normal");
            Assert.True(res.Spo2 == "Normal");
            Assert.True(res.RespRate == "Normal");

            Assert.True(res.PatientInfo.Name == "Subject 1");

        }

        [Fact]
        public void GivenAlertVitalInfoThenReturnVitalStatusAboveOrBelow()
        {
            using var context = new DatabaseContext(ContextOptions);

            var test = new VitalModel()
            {
                IcuId = 1,
                BedId = 5,
                Vitals = new Vitals
                {
                    Bpm = 300,
                    Spo2 = 70,
                    RespRate = 10
                }
            };

            var res = handler.MonitorVitals(test, context);

            Assert.True(res.Bpm == "Above");
            Assert.True(res.Spo2 == "Below");
            Assert.True(res.RespRate == "Below");

            Assert.True(res.PatientInfo.Name == "Subject 2");

        }
    }
}
