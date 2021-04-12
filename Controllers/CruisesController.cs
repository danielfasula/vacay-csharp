using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay_csharp.Models;
using vacay_csharp.Services;

namespace vacay_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CruisesController : ControllerBase
    {
        private readonly CruisesService _cservice;
        public CruisesController(CruisesService cservice)
        {
            _cservice = cservice;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cruise>> Get()
        {
            try
            {
                return Ok(_cservice.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Cruise> Create([FromBody] Cruise newCruise)
        {
            try
            {
                Cruise created = _cservice.Create(newCruise);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Cruise> Get(int id)
        {
            try
            {
                return Ok(_cservice.GetById(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Cruise> Edit([FromBody] Cruise editData, int id)
        {
            try
            {
                editData.Id = id;
                Cruise editedCruise = _cservice.Edit(editData);
                return Ok(editedCruise);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<Cruise> Delete(int id)
        {
            try
            {
                return Ok(_cservice.Delete(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}