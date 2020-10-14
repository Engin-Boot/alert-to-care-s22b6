using System;
using System.Collections.Generic;
using System.Text;
using CaseStudy2.Model;
using Xunit;

namespace AlertToCareTests.ModelTests
{
    public class IcuDataTests
    {
        IcuSetUpData _icuSetUpData = new IcuSetUpData();
        public IcuDataTests()
        {
            _icuSetUpData.IcuId = 1;
            _icuSetUpData.BedsCount = 20;
            _icuSetUpData.Layout = "Cr";
        }
        [Fact]
        public void IcuTest()
        {
            Assert.Equal(1, _icuSetUpData.IcuId);
            Assert.Equal(20, _icuSetUpData.BedsCount);
            Assert.Equal("Cr", _icuSetUpData.Layout);
        }
    }
}
