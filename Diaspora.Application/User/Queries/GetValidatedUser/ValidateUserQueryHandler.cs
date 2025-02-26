﻿using Diaspora.Domain.Abstractions;
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
    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserQuery, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashingService _hashingService;

        public ValidateUserQueryHandler(IUserRepository userRepository, IHashingService hashingService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _hashingService = hashingService ?? throw new ArgumentNullException(nameof(hashingService));
        }

        public async Task<bool> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
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
