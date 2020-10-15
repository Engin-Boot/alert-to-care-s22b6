using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;

namespace AlertToCareAutomatedTest
{
    [TestClass]
    public class OccupancyControllerUpdatePatientDetails
    {
        [TestMethod]
        public void OccupancyControllerUpdatePatientDetailsTest()
        {
            var restClient = new RestClient("http://localhost:53133/api/");
            var restRequest = new RestRequest("Occupancy/4", Method.PUT);

            Model.PatientData patientdetails = new Model.PatientData();
            patientdetails.Bpm = 101.0;
            patientdetails.Spo2 = 95.0;
            patientdetails.RespRate = 60.0;

            restRequest.AddJsonBody(JsonConvert.SerializeObject(patientdetails));
            IRestResponse restResponse = restClient.Execute(restRequest);
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }
    }
}
