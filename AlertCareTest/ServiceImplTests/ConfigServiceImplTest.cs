using alertToCare.Model;
using alertToCare.ServiceImpl;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlertCareTest.ServiceImplTests
{
    public class ConfigServiceImplTest
    {

        ConfigurationImpl configurationImpl = new ConfigurationImpl();
        public ConfigServiceImplTest()
        {

        }

        [Fact]
        public void AddIcuTest()
        {
            IcuSetUpData _icuSetUpData = new IcuSetUpData();
            _icuSetUpData.IcuId = 1;
            _icuSetUpData.BedsCount = 20;
            _icuSetUpData.Layout = "Cr";

            var result = configurationImpl.AddNewIcu(null);
            Assert.False(result);
            Assert.IsType<bool>(result);
        }
    }
}
