using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace ApplicationProcess.Application.Queries.GetApplicant
{
    public class GetApplicantQuery: IRequest<Applicant>
    {
        public int ApplicantId { get; set; }
    }
}