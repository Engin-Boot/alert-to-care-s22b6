using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CaseStudy2.Model;
using System.Collections.Generic;
using System.Data.SQLite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseStudy2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        
        //readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db";
        readonly Service.IOccupancyService _occupancyService;
       // OccupancyServiceImpl occupancyServiceImpl = new OccupancyServiceImpl();
        public OccupancyController(Service.IOccupancyService repo)
        {
            _occupancyService = repo;
        }





        // GET: api/<ValuesController>
        /*   [HttpGet]
           public List<CarData> Get()
           {

                   string cs = "Data Source=:memory:";
                   string stm = "SELECT SQLITE_VERSION()";

                   using var con = new SQLiteConnection(cs);
                   con.Open();

                   using var cmd = new SQLiteCommand(stm, con);
                   string version = cmd.ExecuteScalar().ToString();
                   return version;

               CarData carData = new CarData();
               using var con = new SQLiteConnection(cs);
               con.Open();

               using var cmd = new SQLiteCommand(con);

               cmd.CommandText = "DROP TABLE IF EXISTS cars";
               cmd.ExecuteNonQuery();

               cmd.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY,
                       name TEXT, price INT)";
               cmd.ExecuteNonQuery();

               cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
               cmd.ExecuteNonQuery();

               cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
               cmd.ExecuteNonQuery();
               using var con = new SQLiteConnection(cs);
               con.Open();
               string stm = "SELECT * FROM cars LIMIT 5";

               using var cmd = new SQLiteCommand(stm, con);
               using SQLiteDataReader rdr = cmd.ExecuteReader();
               List<CarData> crDt = new List<CarData>();
               while (rdr.Read())
               {
                   CarData carData = new CarData();
                   carData.Id = rdr.GetInt32(0);
                   carData.Name = rdr.GetString(1);
                   carData.Price= rdr.GetInt32(2);
                   crDt.Add(carData);
               }
               return crDt;
           }*/
        [HttpGet]
        public List<PatientData> GetPatientsDetails()
        {
            try
            {
                var res = _occupancyService.GetPatientsDetails();
                return res;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        [HttpGet("{id}")]
        public List<PatientData> GetPatientDetails(int id)
        {
            try
            {
                var res = _occupancyService.GetPatientDetails(id);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        [HttpGet("bedStatus/{id}")]
        public Object BedStatus( string id)
        {
            try { 
                return Ok(_occupancyService.CheckBedStatus(id)); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadLine();
                return HttpStatusCode.InternalServerError;
            }
            

        }
        [HttpGet("discharge/{id}")]
        public Object Dishcharge(int id)
        {
            try
            {
                return Ok(_occupancyService.DishchargePatient(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadLine();
                return HttpStatusCode.InternalServerError;
            }


        }

        [HttpPost]
        public String AddPatient([FromBody] Model.PatientData value)
        {
            var res =_occupancyService.AddNewPatient(value);
            return "Patient Added:"+ res.ToString();
        }


    }
}
