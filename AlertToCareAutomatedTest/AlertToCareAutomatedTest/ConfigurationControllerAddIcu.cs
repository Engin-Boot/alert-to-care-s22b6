using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;

namespace AlertToCareAutomatedTest
{
    [TestClass]
    public class ConfigurationControllerAddIcu
    {
        [TestMethod]
        public void ConfigurationControllerAddIcuTest()
        {
            RestClient restClient = new RestClient("http://localhost:53133/api/");

            //Creating request to get data from server
            var restRequest = new RestRequest("Configuration/", Method.POST);
            //  restRequest.AddUrlSegment("{id}", 1);
            Model.IcuSetUpData icudata = new Model.IcuSetUpData();
            icudata.BedsCount = 2;
            icudata.Layout = "Circle";

            restRequest.AddJsonBody(JsonConvert.SerializeObject(icudata));

            IRestResponse restResponse = restClient.Execute(restRequest);
            // return restResponse.IsSuccessful;
            Assert.AreEqual(true, restResponse.IsSuccessful);
            //Console.WriteLine(restResponse.Content);
        }
    }
}
