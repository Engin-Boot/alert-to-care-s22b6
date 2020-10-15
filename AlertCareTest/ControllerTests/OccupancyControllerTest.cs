using alertToCare.Controllers;
using alertToCare.Model;
using alertToCare.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlertCareTest.ControllerTests
{
    public class OccupancyControllerTest
    {
        private Mock<IOccupancyService> _mockRepo;

        private OccupancyController occupancyController;

        public OccupancyControllerTest()
        {
            _mockRepo = new Mock<IOccupancyService>();
            occupancyController = new OccupancyController(_mockRepo.Object);
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
            String res = occupancyController.AddPatient(patientData);
            Assert.NotNull(res);
            Assert.IsType<string>(res);
        }
        [Fact]
        public void BedStatusTests()
        {
            var result = occupancyController.BedStatus("b1");
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DischargePatientsTests()
        {
            var result = occupancyController.Dishcharge(1);
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
