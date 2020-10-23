using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Models;
using RepositoryManager.PatientManager;
using System;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IPatientDataHandler _handler;

        public PatientController(DatabaseContext context, IPatientDataHandler handler)
        {
            _context = context;
            _handler = handler;
        }

        [HttpGet("discharge/{PatientId}")]
        public HttpStatusCode DishchargePatient(string PatientId)
        {
            try
            {
                return _handler.RemovePatientFromDb(Int16.Parse(PatientId), _context);
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpPost("AddNewPatient")]
        public HttpStatusCode AddPatient([FromBody] Patient info)
        {
            try
            {
                return _handler.AddPatientToDatabase(info, _context);
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpGet("PatientDetails/{Pid}")]
        public ActionResult GetPatientDetailsById(string Pid)
        {
            try
            {
                return Ok(_handler.GetPatientById(Int16.Parse(Pid), _context));
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpGet("AllPatientDetails")]
        public ActionResult GetAllPatientDetails()
        {
            try
            {
                return Ok(_handler.GetAllPatients(_context));
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
