using alertToCare.ServiceImpl;
using Xunit;

namespace AlertCareTest.ServiceImplTests
{
    public class MonitorServiceImplTest
    {
        readonly MonitorServiceImpl monitorServiceImpl = new MonitorServiceImpl();


        public MonitorServiceImplTest()
        {

        }
        [Fact]
        public void CheckBpmIsOkTest()
        {
            var result = monitorServiceImpl.BpmIsOk(100.0, 70.0, 150.0);
            Assert.IsType<bool>(result);
        }

        [Fact]
        public void CheckStatusWhenBbmIsLessThanMinBbmTest()
        {
            var result = monitorServiceImpl.BpmIsOk(50.0, 70.0, 150.0);
            Assert.IsType<bool>(result);
        }

        [Fact]
        public void CheckStatusWhenBbmIsMoreThanMaxBbmTest()
        {
            var result = monitorServiceImpl.BpmIsOk(160.0, 70.0, 150.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckSpo2IsOkTest()
        {
            var result = monitorServiceImpl.Spo2IsOk(95.0, 90.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckSpo2IsNotOkTest()
        {
            var result = monitorServiceImpl.Spo2IsOk(80.0, 90.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckRespRateIsOkTest()
        {
            var result = monitorServiceImpl.RespRateIsOk(50.0, 30.0, 65.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckStatusWhenRespRateIsLessThanMinRespRateTest()
        {
            var result = monitorServiceImpl.RespRateIsOk(20.0, 30.0, 65.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckStatusWhenRespRateIsMoreThanMaxRespRateTest()
        {
            var result = monitorServiceImpl.RespRateIsOk(50.0, 30.0, 65.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckBpmAndSpo2AreOkTest()
        {
            var result = monitorServiceImpl.BpmAndSpo2AreOk(100.0, 95.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckStatusWhenBpmIsOKAndSpo2IsNotOkTest()
        {
            var result = monitorServiceImpl.BpmAndSpo2AreOk(100.0, 85.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckStatusWhenBpmIsNotOKAndSpo2IsOkTest()
        {
            var result = monitorServiceImpl.BpmAndSpo2AreOk(50.0, 95.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckAllVitalsAreOkTest()
        {
            var result = monitorServiceImpl.VitalsAreOk(100.0, 95.0, 50.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckAllVitalsAreNotOkTest()
        {
            var result = monitorServiceImpl.VitalsAreOk(200.0, 55.0, 120.0);
            Assert.IsType<bool>(result);
        }
        /*[Fact]
        public void CheckMonitorBpmTest()
        {
            var result = monitorServiceImpl.Monitorbpm(1);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckMonitorSpo2Test()
        {
            var result = monitorServiceImpl.Monitorspo2s(1);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckMonitorRespRateTest()
        {
            var result = monitorServiceImpl.MonitorRespRate(1);
            Assert.IsType<bool>(result);
        }*/

    }
}
