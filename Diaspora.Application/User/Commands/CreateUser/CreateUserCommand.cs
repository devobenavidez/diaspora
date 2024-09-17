using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int CreatedById { get; private set; }

        public CreateUserCommand(string userName, string password, int createdById)
        {
            UserName = userName;
            Password = password;
            CreatedById = createdById;
        }

        public void SetCreatedById(int createdById)
        {
            CreatedById = createdById;
        }
    }
}
