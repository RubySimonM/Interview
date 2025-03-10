﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixItService;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1/instruments")]
    public class InstrumentController : ControllerBase
    {
        private readonly IDatabaseService _database;

        public InstrumentController(IDatabaseService database)
        {
            _database = database;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> GetInstruments()
        {
            try
            {
                return Ok(_database.Instruments().Result);
            }           
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}