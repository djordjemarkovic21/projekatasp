using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.CountryCommands;
using Application.DataTransfer;
using Application.Queries.CountryQueries;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public CountryController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/Country
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCountryDto search, [FromServices] IGetCountriesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        // GET: api/Country/5
        [HttpGet("{id}", Name = "GetCountry")]
        public IActionResult Get(int id, [FromServices] IGetCountryQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Country
        [HttpPost]
        public IActionResult Post([FromBody] CountryDto dto, [FromServices] ICreateCountryCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CountryDto dto, [FromServices] IUpdateCountryCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCountryCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
