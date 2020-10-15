using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AlertToCareAutomatedTest
{
    [TestClass]
    public class MonitorControllerSpo2
    {
        [TestMethod]
        public void CheckMontiorConrollerSpo2Test()
        {
            RestClient restClient = new RestClient("http://localhost:53133/api/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Monitor/spo2/1", Method.GET);
            //  restRequest.AddUrlSegment("{id}", 1);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            //  var response = restResponse.Content;
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }
    }
}
