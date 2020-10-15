using alertToCare.Model;
using alertToCare.ServiceImpl;
using Xunit;

namespace AlertCareTest.ServiceImplTests
{
   abstract public class ConfigServiceImplTest
    {
        readonly ConfigurationImpl configurationImpl = new ConfigurationImpl();
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
