using alertToCare.Model;
using alertToCare.ServiceImpl;
using Xunit;

namespace AlertCareTest.ServiceImplTests
{
    public class ConfigServiceImplTest
    {
        readonly ConfigurationImpl configurationImpl = new ConfigurationImpl();
        

        [Fact]
        public void AddIcuTest()
        {
            IcuSetUpData _icuSetUpData = new IcuSetUpData
            {
                IcuId = 1,
                BedsCount = 20,
                Layout = "Cr"
            };

            var result = configurationImpl.AddNewIcu(null);
            Assert.False(result);
            Assert.IsType<bool>(result);
        }

       /* [Fact]
        public void UpdateIcuTest()
        {
            IcuSetUpData _icuSetUpData = new IcuSetUpData
            {
                BedsCount = 20               
            };

            var result = configurationImpl.UpdateIcu(1,null);
            Assert.False(result);
            Assert.IsType<bool>(result);
        }*/
    }
}
