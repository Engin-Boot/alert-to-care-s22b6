using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AlertToCareAutomatedTest
{
    [TestClass]
    public class MonitorControllerRespRate
    {
        [TestMethod]
        public void CheckMontiorConrollerRespRateTest()
        {
            RestClient restClient = new RestClient("http://localhost:62527/api/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("Monitor/resperatoryRate/1", Method.GET);
          //  restRequest.AddUrlSegment("{id}", 1);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
          //  var response = restResponse.Content;
            Assert.AreEqual(true, restResponse.IsSuccessful);
            
        }
    }
}
