using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using CQRSExample.Command;
using CQRSExample.Handlers;
using CQRSExample.Models;
using CQRSExample.Repositories;
using NUnit.Framework.Internal;

public class DeleteStudentHandlerTests : IClassFixture<TestFixture>
{
    public Mock<IStudentRepository> _mockStudentRepository { get; private set; }
    public DeleteStudentHandlerTests(Mock<IStudentRepository> mockStudentRepository)
    {
        _mockStudentRepository = mockStudentRepository;
    }

    [Fact]
    public async Task Handle_ExistingStudent_ShouldDeleteAndReturnId()
    {
        var handler = new DeleteStudentHandler(_mockStudentRepository.Object);
        // Arrange
        var studentId = 1;
        var student = new Student { Id = studentId, StudentName = "John Doe" };

        _mockStudentRepository
            .Setup(repo => repo.GetStudentByIdAsync(studentId))
            .ReturnsAsync(student);

        _mockStudentRepository
            .Setup(repo => repo.DeleteStudentAsync(studentId))
            .ReturnsAsync(studentId);

        var command = new DeleteStudentCommand { Id = studentId };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(studentId, result);
        _mockStudentRepository.Verify(repo => repo.GetStudentByIdAsync(studentId), Times.Once);
        _mockStudentRepository.Verify(repo => repo.DeleteStudentAsync(studentId), Times.Once);
    }

    [Fact]
    public async Task Handle_NonExistingStudent_ShouldReturnDefault()
    {
        var handler = new DeleteStudentHandler(_mockStudentRepository.Object);

        // Arrange
        var studentId = 2;

        _mockStudentRepository
            .Setup(repo => repo.GetStudentByIdAsync(studentId))
            .ReturnsAsync((Student)null);

        var command = new DeleteStudentCommand { Id = studentId };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(default(int), result);
        _mockStudentRepository.Verify(repo => repo.GetStudentByIdAsync(studentId), Times.Once);
        _mockStudentRepository.Verify(repo => repo.DeleteStudentAsync(It.IsAny<int>()), Times.Never);
    }
}
