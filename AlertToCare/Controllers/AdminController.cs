﻿using DatabaseManager;
using Microsoft.AspNetCore.Mvc;
using Models;
using RepositoryManager.FacilityManager;
using System;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly DatabaseContext _context;
        private readonly IFacilityDataHandler _handler;

        public AdminController(DatabaseContext context, IFacilityDataHandler handler)
        {
            _context = context;
            _handler = handler;
        }

        [HttpPost("AddIcu/{BedCount}")]
        public HttpStatusCode AddIcu(string bedCount)
        {
            try
            {
                return _handler.AddNewIcu(Int16.Parse(bedCount), _context);
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpPut("UpdateIcu")]
        public HttpStatusCode UpdateIcuData([FromBody] Facility info)
        {
            try
            {
                return _handler.UpdateIcu(info, _context);
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpGet("IcuDetails/{IcuId}")]
        public ActionResult GetIcuDetailsById(string icuId)
        {
            try
            {
                return Ok(_handler.GetIcuDetailsById(Int16.Parse(icuId), _context));
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpGet("AllIcuDetails")]
        public ActionResult GetAllIcuDetails()
        {
            try
            {
                return Ok(_handler.GetAllIcuDetails(_context));
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}

