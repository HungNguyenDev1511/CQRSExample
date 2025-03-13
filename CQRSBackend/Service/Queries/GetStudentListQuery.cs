using CQRSExample.Models;
using MediatR;

namespace CQRSExample.Queries
{
    public class GetStudentListQuery : IRequest<List<Student>>
    { 
    }
}
