using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.CityCommand;
using Application.DataTransfer;
using Application.Queries.CityQueries;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CityController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/City
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCityDto search, [FromServices] IGetCitiesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/City/5
        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult Get(int id, [FromServices] IGetCityQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/City
        [HttpPost]
        public IActionResult Post([FromBody] CityDto dto, [FromServices] ICreateCityCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CityDto dto, [FromServices] IUpdateCityCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCityCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
