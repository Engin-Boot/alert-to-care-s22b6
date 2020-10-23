using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Models;
using RepositoryManager.Utilities;
using RepositoryManager.VitalManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IVitalDataHandler _handler;

        public VitalsController(DatabaseContext context, IVitalDataHandler handler)
        {
            _context = context;
            _handler = handler;
        }

        [HttpPost("Monitor")]
        public ActionResult MonitorVitals([FromBody] VitalModel info)
        {
            try
            {
                if (!BedListAssist.IsBedOccupied(_context, info.IcuId, info.BedId))
                    return StatusCode(404);

                return Ok(_handler.MonitorVitals(info, _context));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
