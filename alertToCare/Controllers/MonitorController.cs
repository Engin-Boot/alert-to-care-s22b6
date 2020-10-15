using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using alertToCare.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        readonly Service.IMonitorService monitorService;

        public MonitorController(Service.IMonitorService repo)
        {
            monitorService = repo;
        }

        [HttpGet("resperatoryRate/{id}")]
        public string MonitorRespRates(int id)
        {
            if (monitorService.MonitorRespRate(id) == false)
            {
                return "Resperatory rate is not ok for the patient id : " + id;
            }
            return "Resperatory rate is good for the patient id : " + id;
        }

        [HttpGet("spo2/{id}")]
        public string Monitorspo2s(int id)
        {
            if (monitorService.Monitorspo2s(id) == false)
            {
                return "Spo2  is not ok for the patient id : " + id;
            }
            return "Spo2 is good for the patient id : " + id;
        }

        [HttpGet("bpm/{id}")]
        public string Monitorbpms(int id)
        {
            if (monitorService.Monitorbpm(id) == false)
            {
                return "BPM  is not ok for the patient id : " + id;
            }
            return "BPM is good for the patient id : " + id;
        }
    }
}
