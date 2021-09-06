using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.BasketCommands;
using Application.DataTransfer;
using Application.Queries.BasketQueries;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public BasketController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // GET: api/Basket
        [HttpGet]
        public IActionResult Get([FromQuery] SearchBasketDto search, [FromServices] IGetBasketsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Basket/5
        [HttpGet("{id}", Name = "GetBasket")]
        public IActionResult Get(int id, [FromServices] IGetBasketQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Basket
        [HttpPost]
        public IActionResult Post([FromBody] BasketDto dto, [FromServices] ICreateBasketCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Basket/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BasketDto dto, [FromServices] IUpdateBasketCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBasketCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
