using Diaspora.Api.Controllers;
using Diaspora.Application.Users.Commands.CreateUser;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Diaspora.Application.Users.DTOs;
using Diaspora.Application.Users.Queries.GetUsersList;
using Diaspora.Application.Users.Commands.UpdateUser;
using Diaspora.Application.Users.Commands.DeleteUser;

namespace Diaspora.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UsersController _usersController;

        public UserControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _usersController = new UsersController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Post_ShouldReturnCreatedResult_WhenUserIsCreated()
        {
            // Arrange
            var command = new CreateUserCommand("testuser", "Test@1234", 0);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), default)).Returns(Task.FromResult(Unit.Value));

            _usersController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(
                        new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, "1"),
                    }, "TestAuthentication")),
                },
            };

            // Act
            var result = await _usersController.Post(command) as CreatedResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Null(result.Value);
        }

        [Fact]
        public async Task Get_ShouldReturnUsersList_WhenUsersExist()
        {
            // Arrange
            var usersList = new List<UserDto> { new UserDto { UserName = "testuser" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetUsersListQuery>(), default))
                         .ReturnsAsync(usersList);

            // Act
            var result = await _usersController.Get();

            // Assert
            Assert.Equal(usersList, result);
        }

        [Fact]
        public async Task Put_ShouldReturnNoContentResult_WhenUserIsUpdated()
        {
            // Arrange
            var command = new UpdateUserCommand(1, "newPasswordHash", true, 1);
            _usersController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(
                        new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    }, "TestAuthentication")),
                },
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), default)).Returns(Task.FromResult(Unit.Value));

            // Act
            var result = await _usersController.Put(command);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContentResult_WhenUserIsDeleted()
        {
            // Arrange
            var userId = 1;
            _usersController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(
                        new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                    }, "TestAuthentication")),
                },
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteUserCommand>(), default)).Returns(Task.FromResult(Unit.Value));

            // Act
            var result = await _usersController.Delete(userId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
