using alertToCare.Controllers;
using alertToCare.Model;
using alertToCare.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlertCareTest.ControllerTests
{
    public class ConfigurationControllerTest
    {
        private readonly Mock<IIcuConfigurationService> _mockRepo;

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
        }
    }
}
