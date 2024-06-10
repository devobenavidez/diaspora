using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Commands.UpdatePasswordUser
{
    using Diaspora.Application.Exceptions;
    using Diaspora.Application.Users.Commands.UpdateUser;
    using Diaspora.Domain.Abstractions;
    using Diaspora.Infrastructure.Repositories;
    using MediatR;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUser _userRepository;
        private readonly IHashingService _hashingService;

        public UpdateUserCommandHandler(IUser userRepository, IHashingService hashingService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _hashingService = hashingService ?? throw new ArgumentNullException(nameof(hashingService));
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"User with ID {request.UserId} not found.");
            }

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            user.SetPassword(request.NewPasswordHash, _hashingService, salt);

            user.UpdatePassword(request.UpdatedBy);

            if (request.IsActive)
            {
                user.Activate(request.UpdatedBy);
            }
            else
            {
                user.Deactivate(request.UpdatedBy);
            }

            await _userRepository.UpdateUser(user);
        }
    }

}
