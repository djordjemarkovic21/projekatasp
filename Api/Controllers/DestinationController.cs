using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.DestinationCommand;
using Application.DataTransfer;
using Application.Queries;
using Application.Queries.DestinationQueries;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public DestinationController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/Destination
        [HttpGet]
        public IActionResult Get([FromQuery] SearchDestinationDto search, [FromServices] IGetDestinationsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Destination/5
        [HttpGet("{id}", Name = "GetDestination")]
        public IActionResult Get(int id, [FromServices] IGetDestinationQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Destination
        [HttpPost]
        public IActionResult Post([FromBody] DestinationDto dto, [FromServices] ICreateDestinationCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Destination/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DestinationDto dto, [FromServices] IUpdateDestinationCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteDestinationCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
