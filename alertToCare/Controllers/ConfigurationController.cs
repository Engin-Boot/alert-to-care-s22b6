using System;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        readonly Service.IIcuConfigurationService _icuConfigurationService;
        // OccupancyServiceImpl occupancyServiceImpl = new OccupancyServiceImpl();
        public ConfigurationController(Service.IIcuConfigurationService repo)
        {
            _icuConfigurationService = repo;
        }


        [HttpPost("AddIcu/{IcuId}")]
        public ActionResult AddIcu(string IcuId, [FromBody] Model.IcuSetUpData value)
        {
            try
            {
                if (!ModelState.IsValid && string.IsNullOrEmpty(IcuId))
                {
                    return BadRequest(ModelState);
                }
                _icuConfigurationService.AddNewIcu(IcuId, value);
                //return StatusCode(201);  //CreatedAtAction
                return Ok(value);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateIcu/{IcuId}")]
        public ActionResult UpdateIcuData(string IcuId, [FromBody] Model.IcuSetUpData value)
        {
            try
            {
                if (!ModelState.IsValid && string.IsNullOrEmpty(IcuId))
                {
                    return BadRequest(ModelState);
                }
                _icuConfigurationService.UpdateIcu(IcuId, value);
                return Ok(value);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("IcuDetails/{IcuId}")]
        public ActionResult GetIcuDetails(string IcuId)
        {
            try
            {
                var icudetails = _icuConfigurationService.GetIcuDetails(IcuId);
                return Ok(icudetails);
            }
            catch
            {
                return StatusCode(500);  //InternalServerError
            }

        }

    }
}
