using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Queries.GetValidatedUser
{
    public class ValidateUserQuery : IRequest<bool>
    {
        public string UserName { get; }
        public string Password { get; }

        public ValidateUserQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
