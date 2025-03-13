using CQRSExample.Command;
using CQRSExample.Repositories;
using MediatR;

namespace CQRSExample.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (student == null)
                return default;

            student.StudentName = command.StudentName;
            student.StudentEmail = command.StudentEmail;
            student.StudentAddress = command.StudentAddress;
            student.StudentAge = command.StudentAge;

            return await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
