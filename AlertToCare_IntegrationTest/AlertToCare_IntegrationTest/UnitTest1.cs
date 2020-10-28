using System;
using Xunit;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading;


namespace AlertToCare_IntegrationTest
{
    public class UnitTest1
    {
        //ADMIN
        // ADD
        [Fact]
        public void AddNewIcu_ValidRequestPassed_ReturnOk()
        {

            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("admin/AddIcu/10", Method.POST);
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal("200", createdResponse.Content);
        }

        [Fact]
        public void AddNewIcu_InValidRequestPassed_ReturnBadRequest()
        {

            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("admin/AddIcu/", Method.POST);
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal(HttpStatusCode.NotFound, createdResponse.StatusCode);
        }
        //GET
        [Fact]
        public void GetICUDetailsById_WhenCalled()
        {
            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("admin/IcuDetails/1", Method.GET);
            IRestResponse<List<Facility>> okResult = restClient.Execute<List<Facility>>(restRequest);
            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
            Assert.True(okResult.Data[0].BedCount == 10);
            Assert.True(okResult.Data[0].Id == 1);
        }

        [Fact]
        public void GetICUDetailsById_WrongIdEntered_ReturnNoContent()
        {
            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("admin/IcuDetails/100", Method.GET);
            IRestResponse<List<Facility>> okResult = restClient.Execute<List<Facility>>(restRequest);
            Assert.Equal(HttpStatusCode.NoContent, okResult.StatusCode);//responseNotFound
        }
        [Fact]
        public void GetICUDetailsById_Nullip_returnNoContent()
        {
            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("admin/IcuDetails/100", Method.GET);
            IRestResponse<List<Facility>> okResult = restClient.Execute<List<Facility>>(restRequest);
            Assert.Equal(HttpStatusCode.NoContent, okResult.StatusCode);//responseNotFound
        }


        //UPDATE
        [Fact]
        public void UpdateICUDetails_WhenCalled_returnOk()
        {
            var testItem = new Facility()
            {
                Id = 3,
                BedCount = 5,
                OccupiedBeds = ""
            };
            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("admin/UpdateIcu", Method.PUT);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal("200", createdResponse.Content);
        }

        [Fact]
        public void UpdateICUDetails_InvalidIp_returnBadrequest()
        {
            var testItem = new Facility()
            {
             
            };
            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("admin/UpdateIcu", Method.PUT);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal("404", createdResponse.Content);
        }

        //----------------------------------------------------------//
        //Patient Data
        ////Add new patient
        [Fact]
        public void AddNewPatient_ValidRequestPassed_ReturnOk()
        {

            var testItem = new Patient()
            {
                Name = "Max",
                Contact = "245387547",
                IcuId = 3,
                BedId = 1
            };
            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("patient/AddNewPatient/", Method.POST);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal(HttpStatusCode.OK, createdResponse.StatusCode);
        }

        [Fact]
        public void AddNewPatient_InValidRequestPassed_ReturnBadRequest()
        {

            var testItem = new Patient()
            {
                
            };
            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("patient/AddNewPatient/", Method.POST);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal("404", createdResponse.Content);
        }

        //Discharge Patient

        [Fact]
        public void DischargePatient_validIdEntered_returnOk()
        {

            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("patient/discharge/5", Method.GET);
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal(HttpStatusCode.OK, createdResponse.StatusCode);
        }

        [Fact]
        public void DischargePatient_InvalidIdEntered_BadRequest()
        {

            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("patient/discharge/", Method.GET);
            IRestResponse createdResponse = restClient.Execute(restRequest);
            Assert.Equal(HttpStatusCode.NotFound, createdResponse.StatusCode);
        }

        //Get patient by id

        [Fact]
        public void GetPatientDetailsbyId_returnOk()
        {

            RestClient restClient = new RestClient("http://localhost:5000/api/");
            var restRequest = new RestRequest("patient/PatientDetails/1", Method.GET);
            IRestResponse<List<Patient>> okResult = restClient.Execute<List<Patient>>(restRequest);
            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
            Assert.True(okResult.Data[0].Id == 1);
        }

        //-----------------------------------------------------------------------------//
        //Vitals
        //check vital 
       
        //[Fact]
        //public void VitalsCheck_ValidInput_returnOk()
        //{

        //    var testItem = new VitalModel()
        //    {
        //        IcuId=1,
        //        BedId=1,
        //        Vital =
        //        {
        //            Spo2=95,
        //            Bpm=125,
        //            RespRate=60
        //        }
        //    };
        //    RestClient restClient = new RestClient("http://localhost:5000/api/");
        //    var restRequest = new RestRequest("vitals/Monitor", Method.POST);
        //    restRequest.AddJsonBody(JsonConvert.SerializeObject(testItem));
        //    IRestResponse<List<VitalModel>> okResult = restClient.Execute<List<VitalModel>>(restRequest);
        //    Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
           
        //}

    }
}
