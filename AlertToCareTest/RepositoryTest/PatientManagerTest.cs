using DatabaseManager;
using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryManager.PatientManager;
using System.Net;
using Xunit;

namespace AlertToCareTest.RepositoryTest
{
    public class PatientManagerTest : DatabaseTest
    {
        readonly PatientDataHandler handler;
        public PatientManagerTest()
       : base(
           new DbContextOptionsBuilder<DatabaseContext>()
               .UseSqlite("Filename=Test.db")
               .Options)
        {
            handler = new PatientDataHandler();
        }

        [Fact]
        public void GivenPatientInfoThenAddToDatabase()
        {
            using var context = new DatabaseContext(ContextOptions);

            var onep = new Patient()
            {
                Name = "Subject X",
                Contact = "1119777788",
                IcuId = 2,
                BedId = 2
            };

            var res = handler.AddPatientToDatabase(onep, context);

            Assert.True(HttpStatusCode.OK == res);
        }

        [Fact]
        public void GivenPatientInfoWithInvalidIcuIdThenReturnNotFound()
        {
            using var context = new DatabaseContext(ContextOptions);

            var onep = new Patient()
            {
                Name = "Subject X",
                Contact = "1119777788",
                IcuId = 10,
                BedId = 2
            };

            var res = handler.AddPatientToDatabase(onep, context);

            Assert.True(HttpStatusCode.NotFound == res);
        }

        [Fact]
        public void GivenPatientInfoWithInvalidBedIdThenReturnForbidden()
        {
            using var context = new DatabaseContext(ContextOptions);

            var onep = new Patient()
            {
                Name = "Subject X",
                Contact = "1119777788",
                IcuId = 2,
                BedId = 100
            };

            var res = handler.AddPatientToDatabase(onep, context);

            Assert.True(HttpStatusCode.Forbidden == res);
        }

        [Fact]
        public void GivenPatientInfoWithOccupiedThenReturnForbidden()
        {
            using var context = new DatabaseContext(ContextOptions);

            var onep = new Patient()
            {
                Name = "Subject X",
                Contact = "1119777788",
                IcuId = 2,
                BedId = 3
            };

            var res = handler.AddPatientToDatabase(onep, context);

            Assert.True(HttpStatusCode.Forbidden == res);
        }

        [Fact]
        public void GivenValidPatientIdThenRemoveFromDatabase()
        {
            using var context = new DatabaseContext(ContextOptions);

            var res = handler.RemovePatientFromDb(4, context);

            Assert.True(HttpStatusCode.OK == res);
            Assert.True(context.Patients.Find(4) == null);
        }

        [Fact]
        public void GivenGetAllThenReturnAllPatients()
        {
            using var context = new DatabaseContext(ContextOptions);

            var res = handler.GetAllPatients(context);

            Assert.True(res.PatientList.Exists(p => p.Id == 2 && p.Name == "Subject 2"));
        }

        [Fact]
        public void GivenGetByIdThenReturnPatient()
        {
            using var context = new DatabaseContext(ContextOptions);

            var res = handler.GetPatientById(2, context);

            Assert.True(res.Name == "Subject 2");
        }


    }
}
