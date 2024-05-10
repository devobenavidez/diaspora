using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        // Suponiendo que tienes una lista estática de usuarios como ejemplo
        private static readonly List<string> Users = new List<string>
        {
            "Usuario1", "Usuario2", "Usuario3" // etc...
        };

        // Método GET
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Users;
        }
    }
}
