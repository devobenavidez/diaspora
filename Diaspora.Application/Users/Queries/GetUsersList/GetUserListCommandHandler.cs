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
    public class GetUserListCommandHandler : IRequestHandler<GetUsersListCommand, List<UserDto>>
    {
        private readonly IUser _userRepository;

        public GetUserListCommandHandler(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUsersListCommand request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersList();
            List<UserDto> userList = new List<UserDto>();
            foreach (var user in users)
            {
                UserDto userDto = new UserDto();
                userDto.Id = user.Id;
                userDto.UserName = user.UserName;
                userDto.IsActive = user.IsActive;
                userDto.CreatedAt = user.CreatedAt;
                userDto.CreatedBy = user.CreatedBy;
                userDto.UpdatedAt = user.UpdatedAt;
                userDto.UpdatedBy = user.UpdatedBy;
                userDto.DeletedAt = user.DeletedAt;
                userList.Add(userDto);
            }
            return userList;
        }
    }
}
