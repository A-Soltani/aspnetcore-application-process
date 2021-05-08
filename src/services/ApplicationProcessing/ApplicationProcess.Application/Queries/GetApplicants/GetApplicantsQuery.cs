using System.Collections.Generic;
using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace ApplicationProcess.Application.Queries.GetApplicants
{
    public class GetApplicantsQuery: IRequest<IEnumerable<Applicant>>
    {
    }
}