using CQRSExample.Models;
using CQRSExample.Queries;
using CQRSExample.Repositories;
using MediatR;

namespace CQRSExample.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
