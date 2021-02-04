using System.Collections.Generic;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Queries.GetApplicants
{
    public class GetApplicantsQuery: IRequest<IEnumerable<Applicant>>
    {
    }
}