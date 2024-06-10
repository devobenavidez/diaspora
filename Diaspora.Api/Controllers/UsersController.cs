// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Diaspora.Api.Controllers
{
    using Diaspora.Application.Users.Commands.CreateUser;
    using Diaspora.Application.Users.Commands.DeleteUser;
    using Diaspora.Application.Users.Commands.UpdateUser;
    using Diaspora.Application.Users.DTOs;
    using Diaspora.Application.Users.Queries.GetUsersList;
    using Diaspora.Application.Users.Queries.GetValidatedUser;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Suponiendo que tienes una lista estática de usuarios como ejemplo
        private static readonly List<string> Users = new List<string>
        {
            "Usuario1", "Usuario2", "Usuario3", // etc...
        };

        // Método GET
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await _mediator.Send(new GetUsersListCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int createdById = userId != null ? int.Parse(userId) : 0;
            command.SetCreatedById(createdById);
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int updatedById = userId != null ? int.Parse(userId) : 0;
            command.SetUpdatedBy(updatedById);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int deletedById = userId != null ? int.Parse(userId) : 0;
            DeleteUserCommand command = new DeleteUserCommand(id, deletedById);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("validate")]
        public async Task<IActionResult> Validate([FromBody] ValidateUserCommand command)
        {
            var isValid = await _mediator.Send(command);
            if (isValid)
            {
                return Ok(new { Message = "User is valid." });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }
        }
    }
}
