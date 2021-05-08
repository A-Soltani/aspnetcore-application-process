using MediatR;

namespace ApplicationProcess.Application.Commands.DeleteApplicant
{
    public class DeleteApplicantCommand : IRequest
    {
        public int ApplicantId { get; set; }
    }
}