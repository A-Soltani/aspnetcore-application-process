using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace ApplicationProcess.Application.Commands.AddApplicant
{
    public class AddApplicantCommandHandler : IRequestHandler<AddApplicantCommand, int>
    {
        private readonly IApplicantRepository _applicantRepository;

        public AddApplicantCommandHandler(IApplicantRepository applicantRepository) => 
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));

        public async Task<int> Handle(AddApplicantCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.City, request.CountryOfOrigin, request.FullAddress);
            var applicant = Applicant.AddApplicant(request.Name, request.FamilyName, request.Age, request.EmailAddress, address);

            await _applicantRepository.Add(applicant);
            await _applicantRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return applicant.Id;
        }

    }
}