using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.DeleteApplicant
{
    public class DeleteApplicantCommand : IRequest
    {
        public int ApplicantId { get; set; }
    }
}