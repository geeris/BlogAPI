using Blog.Application.Exceptions;
using Blog.Application.Logging;
using Blog.Application.UseCases;
using Blog.Application.UseCases.Commands;
using Blog.Application.UseCases.Commands.TagCommands;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.Application.UseCases.Queries.TagQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagsController : ControllerBase
    {
        //private readonly IExceptionLogger _logger;

        readonly UseCaseExecutor executor;

        public TagsController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<TagsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchDto search, [FromServices] IGetTagsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<TagsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindTagQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<TagsController>
        [HttpPost]
        public void Post([FromBody] TagDto dto, [FromServices] ICreateTagCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<TagsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] TagEditDto dto, [FromServices] IEditTagCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<TagsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand command)
        {
            try
            {
                executor.ExecuteCommand(command, id);
                return NoContent();
            }
            catch(EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
