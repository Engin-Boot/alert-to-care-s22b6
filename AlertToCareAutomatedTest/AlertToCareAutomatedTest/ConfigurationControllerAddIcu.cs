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
        public bool ConfigureNewIcuTest()
        {
            var restClient = new RestClient("http://localhost:54384/api/");
            var restRequest = new RestRequest("Configuration/", Method.POST);
            CaseStudy2.Model.IcuSetUpData icusetdata = new CaseStudy2.Model.IcuSetUpData();
            //icusetdata.IcuId = 3;
            icusetdata.BedsCount = 5;
            icusetdata.Layout = "circle";
            restRequest.AddJsonBody(JsonConvert.SerializeObject(icusetdata));
            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse.IsSuccessful;
        }

    }
}
