using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay_csharp.Models;
using vacay_csharp.Services;

namespace vacay_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly TripsService _tservice;

        public TripsController(TripsService tservice)
        {
            _tservice = tservice;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            try
            {
                return Ok(_tservice.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Trip> Create([FromBody] Trip newTrip)
        {
            try
            {
                Trip created = _tservice.Create(newTrip);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Trip> Get(int id)
        {
            try
            {
                return Ok(_tservice.GetById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Trip> Edit([FromBody] Trip editData, int id)
        {
            try
            {
                editData.Id = id;
                Trip editedTrip = _tservice.Edit(editData);
                return Ok(editedTrip);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Trip> Delete(int id)
        {
            try
            {
                return Ok(_tservice.Delete(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}