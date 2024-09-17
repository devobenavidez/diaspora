using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int UserId { get; private set; }

        public string NewPasswordHash { get; private set; }
        public bool IsActive { get; private set; }

        public int UpdatedBy { get; private set; }

        public UpdateUserCommand(int userId, string newPasswordHash, bool isActive, int updatedBy)
        {
            UserId = userId;
            NewPasswordHash = newPasswordHash;
            IsActive = isActive;
            UpdatedBy = updatedBy;
        }

        public void SetUpdatedBy(int updatedBy)
        {
            UpdatedBy = updatedBy;
        }
    }
}
