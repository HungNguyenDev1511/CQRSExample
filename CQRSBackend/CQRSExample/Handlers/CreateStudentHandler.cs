using CQRSExample.Command;
using CQRSExample.Models;
using CQRSExample.Repositories;
using MediatR;

namespace CQRSExample.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                StudentName = command.StudentName,
                StudentEmail = command.StudentEmail,
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge
            };

            return await _studentRepository.AddStudentAsync(student);
        }
    }
}
