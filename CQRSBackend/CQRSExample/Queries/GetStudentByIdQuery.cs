using CQRSExample.Models;
using MediatR;

namespace CQRSExample.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
