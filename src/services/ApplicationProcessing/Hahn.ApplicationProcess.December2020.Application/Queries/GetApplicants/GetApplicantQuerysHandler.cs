using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Application.Queries.GetApplicant;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Queries.GetApplicants
{
    public class GetApplicantsQueryHandler: IRequestHandler<GetApplicantsQuery, IEnumerable<Applicant>>
    {
        private readonly IApplicantRepository _applicantRepository;

        public GetApplicantsQueryHandler(IApplicantRepository applicantRepository) => 
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));

        public async Task<IEnumerable<Applicant>> Handle(GetApplicantsQuery request, CancellationToken cancellationToken) => 
            await _applicantRepository.GetList();
    }
}