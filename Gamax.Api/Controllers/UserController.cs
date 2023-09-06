using Gamax.Application.Features.Users.Command.CreateUser;
using Gamax.Application.Features.Users.Command.DeleteUser;
using Gamax.Application.Features.Users.Command.UpdateUser;
using Gamax.Application.Features.Users.Queries.GetUser;
using Gamax.Application.Features.Users.Queries.GetUsersList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gamax.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Authorize]
        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserListVm>>> GetAllUsers()
        {
            var dtos = await _mediator.Send(new GetUserListQuery());
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<GetUserDto>> GetUserById(Guid id)
        {
            var getEventDetailQuery = new GetUserQuery()
            {
                UserId = id
            };

            return (await _mediator.Send(getEventDetailQuery));
        }

        [Authorize]
        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var createUserResponse = await _mediator.Send(createUserCommand);
            return Ok(createUserResponse);
        }

        [Authorize]
        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteUserCommand = new DeleteUserCommand() { UserId = id }; 
            await _mediator.Send(deleteUserCommand);
            return NoContent();
        }
    }
}
