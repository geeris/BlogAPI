using Blog.Application.UseCases;
using Blog.Application.UseCases.Commands;
using Blog.Application.UseCases.Commands.UserCommands;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.Application.UseCases.Queries.UserQueries;
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
    public class UsersController : ControllerBase
    {
        readonly UseCaseExecutor executor;

        public UsersController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindUserQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<UsersController>
        [AllowAnonymous]
        [HttpPost]
        public void Post([FromBody] UserRegistrationDto dto, [FromServices] IUserRegistrationCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<UserController>/5
        [HttpPatch("{id}")]
        public void Patch([FromBody] UserEditDto dto, [FromServices] IEditUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            executor.ExecuteCommand(command, id);
        }
    }
}
