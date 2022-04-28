using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _stateService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _stateService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost]
        public IActionResult Add(State state)
        {
            var result = _stateService.Add(state);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(State state)
        {
            var result = _stateService.Update(state);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete]
        public IActionResult Delete(State state)
        {
            var result = _stateService.Delete(state);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
