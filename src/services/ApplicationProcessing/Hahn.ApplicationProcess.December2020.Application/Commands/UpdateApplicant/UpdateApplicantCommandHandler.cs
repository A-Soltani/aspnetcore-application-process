using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, bool>
    {
        private readonly IApplicantRepository _applicantRepository;

        public UpdateApplicantCommandHandler(IApplicantRepository applicantRepository) =>
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));

        public async Task<bool> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.Get(request.ApplicantId);
            if (applicant == null)
                return false;

            _applicantRepository.Update(applicant);
            return await _applicantRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}