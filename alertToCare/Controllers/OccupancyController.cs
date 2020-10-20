using System;
using System.Collections.Generic;
using System.Net;
using alertToCare.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {

        readonly Service.IOccupancyService _occupancyService;

        public OccupancyController(Service.IOccupancyService repo)
        {
            _occupancyService = repo;
        }


        [HttpGet("patientdetails/{id}")]
        public ActionResult<IEnumerable<PatientData>> GetPatientDetails(string PatientId)
        {
            try
            {
                var res = _occupancyService.GetPatientDetails(PatientId);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpGet("bedStatus/{BedId}")]
        public ActionResult BedStatus(string BedId)
        {
            try
            {
                var res = _occupancyService.CheckBedStatus(BedId);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500);//InternalServerError
            }


        }

        [HttpGet("discharge/{PatientId}")]
        public ActionResult DishchargePatient(string PatientId)
        {
            try
            {
                var res = _occupancyService.DishchargePatient(PatientId);
                return Ok(res);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("AddNewPatient")]
        public ActionResult AddPatient([FromBody] Model.PatientData value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _occupancyService.AddNewPatient(value);
                return StatusCode(201);  //CreatedAtAction
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("updatePatientInfo/{PatientId}")]
        public ActionResult UpdatePatientDetails(string PatientId, [FromBody] Model.PatientData value)
        {
            try
            {
                if (!ModelState.IsValid && string.IsNullOrEmpty(PatientId))
                {
                    return BadRequest(ModelState);
                }
                _occupancyService.UpdatePatientInfo(PatientId, value);
                return Ok(value);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
