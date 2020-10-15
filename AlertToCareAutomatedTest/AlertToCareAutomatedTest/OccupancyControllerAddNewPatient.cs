using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;


namespace AlertToCareAutomatedTest
{
    [TestClass]
    public class OccupancyControllerAddNewPatient
    {
        [TestMethod]
        public void OccupancyControllerAddNewPatientTest()
        {
            var restClient = new RestClient("http://localhost:53133/api/");
            var restRequest = new RestRequest("Occupancy/", Method.POST);
            Model.PatientData patientdetails = new Model.PatientData();
            patientdetails.IcuId = 1;
            patientdetails.BedId = "b3";
            patientdetails.Name = "pranshusachan";
            patientdetails.Address = "vpo baraur";
            patientdetails.Email = "psachan@gmail.com";
            patientdetails.Bpm = 101.0;
            patientdetails.Spo2 = 95.0;
            patientdetails.RespRate = 60.0;
            restRequest.AddJsonBody(JsonConvert.SerializeObject(patientdetails));
            IRestResponse restResponse = restClient.Execute(restRequest);
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }
    }
}
