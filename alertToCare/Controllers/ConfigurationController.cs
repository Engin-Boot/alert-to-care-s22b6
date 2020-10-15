using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        [HttpPost]
        // POST api/<ConfigurationController>
        public String AddIcu([FromBody] Model.IcuSetUpData value)
        {
            var res = _icuConfigurationService.AddNewIcu(value);
            return "New Icu Added :" + res.ToString();
        }
        [HttpPut("{id}")]
        public string UpdateIcuData(int id, [FromBody] Model.IcuSetUpData value)
        {
            var res = _icuConfigurationService.UpdateIcu(id, value);
            return "Icu Data Updated successfully :" + res.ToString();
        }
    }
}
