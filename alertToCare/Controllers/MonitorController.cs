using System;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        readonly Service.IMonitorService _monitorService;

        public MonitorController(Service.IMonitorService repo)
        {
            _monitorService = repo;
        }

        [HttpGet("resperatoryRate/{id}")]
        public IActionResult MonitorRespRates(int id)
        {
            string result;
            if (_monitorService.MonitorRespRate(id) == false)
            {
                _ = "Resperatory rate is not ok for the patient id : " + id;
            }
            result= "Resperatory rate is good for the patient id : " + id;
            return Ok(result);
        }

        [HttpGet("spo2/{id}")]
        public string Monitorspo2(int id)
        {
            if (_monitorService.Monitorspo2(id) == false)
            {
                return "Spo2  is not ok for the patient id : " + id;
            }
            return "Spo2 is good for the patient id : " + id;
        }

        [HttpGet("bpm/{id}")]
        public string Monitorbpms(int id)
        {
            if (_monitorService.Monitorbpm(id) == false)
            {
                return "BPM  is not ok for the patient id : " + id;
            }
            return "BPM is good for the patient id : " + id;
        }
    }
}
