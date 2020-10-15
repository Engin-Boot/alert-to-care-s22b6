using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;

namespace AlertToCareAutomatedTest
{
    [TestClass]
    public class ConfigurationContollerUpdateIcu
    {
        [TestMethod]
        public void ConfigurationContollerUpdateIcuTest()
        {
            var restClient = new RestClient("http://localhost:53133/api/");
            var restRequest = new RestRequest("Configuration/4", Method.PUT);

            Model.IcuSetUpData icudata = new Model.IcuSetUpData();
            icudata.BedsCount = 2;

            restRequest.AddJsonBody(JsonConvert.SerializeObject(icudata));
            IRestResponse restResponse = restClient.Execute(restRequest);
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }
    }
}
