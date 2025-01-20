using DeveloperStore.Core.Exceptions;
using DeveloperStore.Users.Application.Commands.CreateUser;
using DeveloperStore.Users.Application.Commands.DeleteUserCommand;
using DeveloperStore.Users.Application.Commands.UpdateUser;
using DeveloperStore.Users.Application.DTOs;
using DeveloperStore.Users.Application.Queries.GetAllUser;
using DeveloperStore.Users.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DeveloperStore.Users.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponseDto), 200)]
        public async Task<IActionResult> GetAllUsers([FromQuery] int _page = 1,
                                                     [FromQuery] int _size = 10,
                                                     [FromQuery] string _order = "")
        {
            var query = new GetAllUsersQuery(_page, _size, _order);
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest("ID in URL and body must match.");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            } catch(NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserCommand(id));

                return Ok(result);
            } 
            catch(NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}