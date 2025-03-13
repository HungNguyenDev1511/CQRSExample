using CQRSExample.Command;
using CQRSExample.Repositories;
using MediatR;

namespace CQRSExample.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (student == null)
                return default;

            return await _studentRepository.DeleteStudentAsync(student.Id);
        }
    }
}
