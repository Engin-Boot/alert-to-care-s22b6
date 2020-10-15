using alertToCare.Controllers;
using alertToCare.Service;
using Moq;
using Xunit;

namespace AlertCareTest.ControllerTests
{
   abstract public class MonitorControllerTest
    {
        private readonly Mock<IMonitorService> _mockRepo;

        private readonly MonitorController _monitorController;
        public MonitorControllerTest()
        {
            _mockRepo = new Mock<IMonitorService>();
            _monitorController = new MonitorController(_mockRepo.Object);
        }

        [Fact]
        public void MonitorRespRatesTest()
        {
            var result = _monitorController.MonitorRespRates(1);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
        [Fact]
        public void Monitorspo2Test()
        {
            var result = _monitorController.Monitorspo2(1);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
        [Fact]
        public void MonitorbpmsTest()
        {
            var result = _monitorController.Monitorbpms(1);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}
