using Diaspora.Application.Users.DTOs;
using Diaspora.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Queries.GetUsersList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersList();
            List<UserDto> userList = new List<UserDto>();
            foreach (var user in users)
            {
                UserDto userDto = new UserDto();
                userDto.Id = user.Id.Value;
                userDto.UserName = user.UserName.Value;
                userDto.IsActive = user.IsActive;
                userDto.CreatedAt = user.AuditInfo.CreatedAt;
                userDto.CreatedBy = user.AuditInfo.CreatedBy;
                userDto.UpdatedAt = user.AuditInfo.UpdatedAt;
                userDto.UpdatedBy = user.AuditInfo.UpdatedBy;
                userDto.DeletedAt = user.AuditInfo.DeletedAt;
                userList.Add(userDto);
            }
            return userList;
        }
    }
}
