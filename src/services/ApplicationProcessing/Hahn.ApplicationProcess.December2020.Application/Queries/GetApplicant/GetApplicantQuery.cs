using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Queries.GetApplicant
{
    public class GetApplicantQuery: IRequest<Applicant>
    {
        public int ApplicantId { get; set; }
    }
}