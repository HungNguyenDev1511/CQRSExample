using MediatR;

namespace CQRSExample.Command
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
