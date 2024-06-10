using Diaspora.Domain.Abstractions;
using Diaspora.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Application.Users.Queries.GetValidatedUser
{
    public class ValidateUserCommandHandler : IRequestHandler<ValidateUserCommand, bool>
    {
        private readonly IUser _userRepository;
        private readonly IHashingService _hashingService;

        public ValidateUserCommandHandler(IUser userRepository, IHashingService hashingService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _hashingService = hashingService ?? throw new ArgumentNullException(nameof(hashingService));
        }

        public async Task<bool> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);

            if (user == null)
            {
                return false;
            }

            string hashedPassword = _hashingService.HashPassword(request.Password, user.Salt.Value);

            return user.PasswordHash.Value == hashedPassword;
        }
    }
}
