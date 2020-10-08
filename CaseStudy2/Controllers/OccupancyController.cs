using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseStudy2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        //readonly string cs = @"URI=file:C:\csvfolder\test.db";
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

        [HttpGet("{id}")]
        public Object BedStatus(int id)
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
        [HttpPost]
        public String AddPatient([FromBody] Model.PatientData value)
        {
            _occupancyService.AddNewPatient(value);
            return "Patient Added";
        }


    }
}
