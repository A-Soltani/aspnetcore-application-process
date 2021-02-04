using System;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Queries.GetApplicant
{
    public class GetApplicantQueryHandler: IRequestHandler<GetApplicantQuery, Applicant>
    {
        private readonly IApplicantRepository _applicantRepository;

        public GetApplicantQueryHandler(IApplicantRepository applicantRepository) => 
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));

        public async Task<Applicant> Handle(GetApplicantQuery request, CancellationToken cancellationToken) => 
            await _applicantRepository.Get(request.ApplicantId);
    }
}