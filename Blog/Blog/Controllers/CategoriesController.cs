using Blog.Application.Exceptions;
using Blog.Application.UseCases;
using Blog.Application.UseCases.Commands;
using Blog.Application.UseCases.Commands.CategoryCommands;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.Application.UseCases.Queries.CategoryQueries;
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
    public class CategoriesController : ControllerBase
    {
        readonly UseCaseExecutor executor;

        public CategoriesController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchDto search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCategoryQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] CategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] CategoryEditDto dto, [FromServices] IEditCategoryCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
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
