using CaseStudy2.Model;
using CaseStudy2.ServiceImpl;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlertToCareTests.ServiceImplTests
{
    public class ConfigServiceImplTest
    {
        IcuSetUpData _icuSetUpData = new IcuSetUpData();
        ConfigurationImpl configurationImpl = new ConfigurationImpl();
        public ConfigServiceImplTest()
        {
            _icuSetUpData.IcuId = 1;
            _icuSetUpData.BedsCount = 20;
            _icuSetUpData.Layout = "Cr";
        }

        [Fact]
        public void AddIcuTest()
        {

            var result = configurationImpl.AddNewIcu(_icuSetUpData);
            Assert.IsType<bool>(result);
        }
    }
}
