using Blog.Application.UseCases;
using Blog.Application.UseCases.Commands.CommentCommands;
using Blog.Application.UseCases.DTO;
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
    public class CommentsController : ControllerBase
    {
        readonly UseCaseExecutor executor;

        public CommentsController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST api/<CommentsController>
        [HttpPost]
        public void Post([FromBody] CreateCommentDto dto, [FromServices] ICreateCommentCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            executor.ExecuteCommand(command, id);
        }
    }
}
