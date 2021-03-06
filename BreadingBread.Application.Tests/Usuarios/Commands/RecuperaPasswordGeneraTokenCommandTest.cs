﻿using BreadingBread.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken;
using BreadingBread.Infraestructure;
using MediatR;
using Moq;
using System.Threading;
using Xunit;

namespace BreadingBread.Application.Tests.Usuarios.Commands
{
    public class RecuperaPasswordGeneraTokenCommandTest : TestBase
    {

        [Fact]
        public void Handle_InValidRequest_ShouldNotRaiseUsuarioNotification()
        {
            string email = "alumnoo@asd.com";
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new RecuperaPasswordGeneraTokenHandler(context, new RandomGenerator(), mediatorMock.Object);

            // Act
            var result = sut.Handle(new RecuperaPasswordGeneraTokenCommand
            {
                UserName = email
            }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<RecuperaPasswordGeneraTokenNotificate>(cc => cc.Email == email && cc.Token != null), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
