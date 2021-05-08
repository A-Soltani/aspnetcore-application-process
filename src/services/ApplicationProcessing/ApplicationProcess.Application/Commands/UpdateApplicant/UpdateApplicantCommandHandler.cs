using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationProcess.Application.Exceptions;
using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace ApplicationProcess.Application.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandHandler : AsyncRequestHandler<UpdateApplicantCommand>
    {
        private readonly IApplicantRepository _applicantRepository;

        public UpdateApplicantCommandHandler(IApplicantRepository applicantRepository) =>
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));

        protected override async Task Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.Get(request.ApplicantId);
            if (applicant == null)
                throw new NotFoundException(nameof(Applicant), request.ApplicantId);

            _applicantRepository.Update(applicant);
             await _applicantRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}