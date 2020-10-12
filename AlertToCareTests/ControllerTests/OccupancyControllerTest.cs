﻿using CaseStudy2.Controllers;
using CaseStudy2.Model;
using CaseStudy2.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;
namespace AlertToCareTests.ControllerTests
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
            Assert.Equal("Patient Added", res);
        }
        [Fact]
        public void BedStatusTests()
        {
            var result = occupancyController.BedStatus(1);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}