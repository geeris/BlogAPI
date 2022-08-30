using Blog.Application.UseCases;
using Blog.Application.UseCases.Commands.PostCommands;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries.PostQueries;
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
    public class PostsController : ControllerBase
    {
        readonly UseCaseExecutor executor;

        public PostsController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearchDto search, [FromServices] IGetPostsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindPostQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<PostsController>
        [HttpPost]
        public void Post([FromBody] CreatePostDto dto, [FromServices] ICreatePostCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromServices] IDeletePostCommand command)
        {
            executor.ExecuteCommand(command, id);
        }
    }
}
