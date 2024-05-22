// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Diaspora.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        // Suponiendo que tienes una lista estática de usuarios como ejemplo
        private static readonly List<string> Users = new List<string>
        {
            "Usuario1", "Usuario2", "Usuario3", // etc...
        };

        // Método GET
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string nuevoUsuario = "Usuario4";
            string newUsuario = "Usuario6";
            return Users;
        }
    }
}
