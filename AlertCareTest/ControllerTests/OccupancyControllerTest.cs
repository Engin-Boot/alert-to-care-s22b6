using alertToCare.Controllers;
using alertToCare.Model;
using alertToCare.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace AlertCareTest.ControllerTests
{
   abstract public class OccupancyControllerTest
    {
        private readonly Mock<IOccupancyService> _mockRepo;

        private readonly OccupancyController _occupancyController;

        public OccupancyControllerTest()
        {
            _mockRepo = new Mock<IOccupancyService>();
            _occupancyController = new OccupancyController(_mockRepo.Object);
        }
        [Fact]
        public void AddPatientsTests()
        {
            PatientData patientData = new PatientData();
            patientData.Name = "CSv";
            patientData.RespRate = 21.0;
            patientData.Bpm = 90.0;
            patientData.Spo2 = 45.0;
            patientData.Address = "";
            patientData.Email = "csv@hmail.com";
            String res = _occupancyController.AddPatient(patientData);
            Assert.NotNull(res);
            Assert.IsType<string>(res);
        }
        [Fact]
        public void BedStatusTests()
        {
            var result = _occupancyController.BedStatus("b1");
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DischargePatientsTests()
        {
            var result = _occupancyController.Dishcharge(1);
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
