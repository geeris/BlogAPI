using Blog.Application.UseCases;
using Blog.Application.UseCases.Queries;
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
    public class ExceptionLogsController : ControllerBase
    {
        readonly UseCaseExecutor executor;

        public ExceptionLogsController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET api/<ExceptionLogsController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] string Guid, [FromServices] IFindExceptionLogQuery query)
        {
            return Ok(executor.ExecuteQuery(query, Guid));
        }
    }
}
