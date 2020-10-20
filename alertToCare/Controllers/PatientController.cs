using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Models;
using RepositoryManager.PatientManager;

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
                return _handler.RemovePatientFromDb(Int16.Parse(PatientId),_context);
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
                if (!ModelState.IsValid)
                {
                    return HttpStatusCode.BadRequest;
                }
                return _handler.AddPatientToDatabase(info,_context);
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
