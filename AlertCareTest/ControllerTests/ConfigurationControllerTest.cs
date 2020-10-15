using alertToCare.Controllers;
using alertToCare.Model;
using alertToCare.Service;
using Moq;
using Xunit;

namespace AlertCareTest.ControllerTests
{
     public class ConfigurationControllerTest
    {
        private readonly Mock<IIcuConfigurationService> _mockRepo;

        private readonly ConfigurationController _configurationController;

        public ConfigurationControllerTest()
        {
            _mockRepo = new Mock<IIcuConfigurationService>();
            _configurationController = new ConfigurationController(_mockRepo.Object);
        }
        [Fact]
        public void AddIcuTest()
        {
            IcuSetUpData icudata = new IcuSetUpData
            {
                IcuId = 2,
                BedsCount = 3,
                Layout = "CIRCLE"
            };
            string result = _configurationController.AddIcu(icudata);
            Assert.IsType<string>(result);
        }
        [Fact]
        public void UpdateIcuDataTest()
        {
            IcuSetUpData icudata = new IcuSetUpData
            {                
                BedsCount = 3                
            };
            string result = _configurationController.UpdateIcuData(2,icudata);
            Assert.IsType<string>(result);
        }
    }
}
