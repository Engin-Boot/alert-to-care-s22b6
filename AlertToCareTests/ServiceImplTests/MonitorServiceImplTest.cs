using CaseStudy2.Controllers;
using CaseStudy2.Service;
using CaseStudy2.ServiceImpl;
using CaseStudy2.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace AlertToCareTests.ServiceImplTests
{
   public class MonitorServiceImplTest
   {
        private Mock<IMonitorService> _mockRepo;

        private MonitorServiceImpl monitorServiceImpl = new MonitorServiceImpl();


        public MonitorServiceImplTest()
        {
            _mockRepo = new Mock<IMonitorService>();
        }
        [Fact]
        public void CheckBpmIsOkTest()
        {
            var result = monitorServiceImpl.BpmIsOk(100.0, 70.0, 150.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckSpo2IsOkTest()
        {
            var result = monitorServiceImpl.Spo2IsOk(95.0, 90.0);
            Assert.IsType<bool>(result);
        }
        [Fact]
        public void CheckRespRateIsOkTest()
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
        public void CheckAllVitalsAreOkTest()
        {
            var result = monitorServiceImpl.VitalsAreOk(100.0, 95.0, 50.0);
            Assert.IsType<bool>(result);
        }
       /* [Fact]
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
