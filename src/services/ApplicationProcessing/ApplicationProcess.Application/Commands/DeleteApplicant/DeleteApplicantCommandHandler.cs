using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationProcess.Application.Exceptions;
using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace ApplicationProcess.Application.Commands.DeleteApplicant
{
    public class DeleteApplicantCommandHandler : AsyncRequestHandler<DeleteApplicantCommand>
    {
        private readonly IApplicantRepository _applicantRepository;

        public DeleteApplicantCommandHandler(IApplicantRepository applicantRepository) =>
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));

        protected override async Task Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.Get(request.ApplicantId);
            if (applicant == null)
                throw new NotFoundException(nameof(Applicant), request.ApplicantId);

            _applicantRepository.Delete(applicant);
            await _applicantRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}