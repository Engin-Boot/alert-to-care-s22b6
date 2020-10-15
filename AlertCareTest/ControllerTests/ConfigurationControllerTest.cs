using alertToCare.Controllers;
using alertToCare.Model;
using alertToCare.Service;
using Moq;
using Xunit;

namespace AlertCareTest.ControllerTests
{
    abstract public class ConfigurationControllerTest
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
            IcuSetUpData icudata = new IcuSetUpData();
            icudata.IcuId = 2;
            icudata.BedsCount = 3;
            icudata.Layout = "CIRCLE";
            string result = _configurationController.AddIcu(icudata);
            Assert.IsType<string>(result);
        }
    }
}
