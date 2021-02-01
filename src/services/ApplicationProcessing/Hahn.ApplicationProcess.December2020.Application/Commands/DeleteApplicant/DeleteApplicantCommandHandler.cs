using System;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Application.Commands.UpdateApplicant;
using Hahn.ApplicationProcess.December2020.Application.Exceptions;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.DeleteApplicant
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