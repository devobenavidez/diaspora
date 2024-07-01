using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; private set; }

        public int DeletedBy { get; private set; }

        public DeleteUserCommand(int userId, int deletedBy)
        {
            UserId = userId;
            DeletedBy = deletedBy;
        }
    }
}
