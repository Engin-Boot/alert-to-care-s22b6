using System;
using System.Collections.Generic;
using System.Text;
using CaseStudy2.Controllers;
using CaseStudy2.Model;
using CaseStudy2.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AlertToCareTests.ControllerTests
{
    public class ConfigurationControllerTest
    {
        /* private readonly Mock<IIcuConfigurationService> _mockRepo;

        private readonly ConfigurationController configurationController;

        public ConfigurationControllerTest()
        {
            _mockRepo = new Mock<IIcuConfigurationService>();
            configurationController = new ConfigurationController(_mockRepo.Object);
        }
       [Fact]
        public void AddIcuTest()
        {
            IcuSetUpData icudata = new IcuSetUpData();
            icudata.IcuId = 2;
            icudata.BedsCount = 3;
            icudata.Layout = "CIRCLE";
            string result = configurationController.AddIcu(icudata);
            Assert.IsType<string>(result);
        }*/
    }
}
