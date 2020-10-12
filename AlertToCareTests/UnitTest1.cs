using CaseStudy2.Controllers;
using CaseStudy2.Model;
using CaseStudy2.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace AlertToCareTests
{
    public class UnitTest1
    {
        private readonly Mock<IOccupancyService> _mockRepo;

        private readonly OccupancyController occupancyController;

        public UnitTest1()
        {
            _mockRepo = new Mock<IOccupancyService>();
            occupancyController = new OccupancyController(_mockRepo.Object);
        }
        [Fact]
        public void Test1()
        {
            PatientData patientData = new PatientData();
            patientData.Name = "CSv";
            patientData.RespRate = 21.0;
            patientData.Bpm = 90.0;
            patientData.Spo2 = 45.0;
            patientData.Address = "";
            patientData.Email = "csv@hmail.com";
            String res = occupancyController.AddPatient(null);
            Assert.Equal("Patient Added", res);
        }
        [Fact]
        public void WhenGetVitalsExecutesReturnsTypeVitals()
        {
            var result = occupancyController.BedStatus(1);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
