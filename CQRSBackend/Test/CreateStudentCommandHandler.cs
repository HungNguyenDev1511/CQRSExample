using CQRSExample.Command;
using CQRSExample.Handlers;
using CQRSExample.Models;
using CQRSExample.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{

    public class CreateStudentCommandHandler
    {
        public Mock<IStudentRepository> _mockStudentRepository { get; private set; }
        public CreateStudentCommandHandler(Mock<IStudentRepository> mockStudentRepository) {
            _mockStudentRepository = mockStudentRepository;
        }    
        [Fact]
        public async Task Handle_ValidCommand_ShouldCreateStudentSuccessfully()
        {
            // Arrange
            var mockRepository = _mockStudentRepository;
            var handler = new CreateStudentHandler(mockRepository.Object);

            var createCommand = new CreateStudentCommand(
                "John Doe",
                "johndoe@example.com",
                "123 Main St",
                22
            );

            var expectedStudent = new Student
            {
                StudentName = createCommand.StudentName,
                StudentEmail = createCommand.StudentEmail,
                StudentAddress = createCommand.StudentAddress,
                StudentAge = createCommand.StudentAge
            };

            mockRepository
                .Setup(repo => repo.AddStudentAsync(It.IsAny<Student>()))
                .ReturnsAsync((Student s) => s);

            // Act
            var result = await handler.Handle(createCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedStudent.StudentName, result.StudentName);
            Assert.Equal(expectedStudent.StudentEmail, result.StudentEmail);
            Assert.Equal(expectedStudent.StudentAddress, result.StudentAddress);
            Assert.Equal(expectedStudent.StudentAge, result.StudentAge);

            // Đảm bảo phương thức AddStudentAsync đã được gọi đúng 1 lần
            mockRepository.Verify(repo => repo.AddStudentAsync(It.IsAny<Student>()), Times.Once);
        }

    }
}
