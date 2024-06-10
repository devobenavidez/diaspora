using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Queries.GetValidatedUser
{
    public class ValidateUserCommand : IRequest<bool>
    {
        public string UserName { get; }
        public string Password { get; }

        public ValidateUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
