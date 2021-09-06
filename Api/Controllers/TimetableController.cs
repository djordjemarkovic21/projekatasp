using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.TimetableCommands;
using Application.DataTransfer;
using Application.Queries.TimetableQueries;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public TimetableController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Timetable
        [HttpGet]
        public IActionResult Get([FromQuery] SearchTimetableDto search, [FromServices] IGetTimetablesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Timetable/5
        [HttpGet("{id}", Name = "GetTimetable")]
        public IActionResult Get(int id, [FromServices] IGetTimetableQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Timetable
        [HttpPost]
        public IActionResult Post([FromBody] TimetableDto dto, [FromServices] ICreateTimetableCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Timetable/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TimetableDto dto, [FromServices] IUpdateTimetableCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTimetableCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
