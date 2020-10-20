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

        [HttpGet("vitals/{id}/{bpm}/{spo2}/{resprate}")]
        public string MonitorVitals(string id, double bpm, double spo2, double resprate)
        {
            if (_monitorService.VitalsAreOk(id, bpm, spo2, resprate) == false)
            {
                return "Vitals is not ok for the patient id : " + id;
            }
            return "Vitals is good for the patient id : " + id;
        }
    }
}
