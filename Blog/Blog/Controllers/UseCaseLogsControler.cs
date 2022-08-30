using Blog.Application.UseCases;
using Blog.Application.UseCases.DTO;
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
    public class UseCaseLogsControler : ControllerBase
    {
        readonly UseCaseExecutor executor;

        public UseCaseLogsControler(UseCaseExecutor executor)
        {
            this.executor = executor;
        }
        // GET: api/<UseCaseLogsControler>
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearchDto dto, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, dto));
        }
    }
}
