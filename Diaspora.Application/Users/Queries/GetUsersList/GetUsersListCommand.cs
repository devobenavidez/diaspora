using Diaspora.Application.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Queries.GetUsersList
{
    public class GetUsersListCommand : IRequest<List<UserDto>>
    {
    }
}
