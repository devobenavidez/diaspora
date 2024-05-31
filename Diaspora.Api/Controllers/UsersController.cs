// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Diaspora.Api.Controllers
{
    using Diaspora.Application.Users.DTOs;
    using Diaspora.Application.Users.Queries.GetUsersList;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

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
    }
}
