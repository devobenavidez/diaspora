using Diaspora.Application.Exceptions;
using Diaspora.Application.Users.Commands.DeleteUser;
using Diaspora.Domain.Abstractions;
using Diaspora.Infrastructure.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUser _userRepository;

    public DeleteUserCommandHandler(IUser userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);

        if (user == null)
        {
            throw new NotFoundException($"User with ID {request.UserId} not found.");
        }

        user.Delete(request.DeletedBy);
        await _userRepository.DeleteUser(user);
    }
}
