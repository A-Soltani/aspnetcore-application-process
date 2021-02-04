﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant;
using Hahn.ApplicationProcess.December2020.Application.Exceptions;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.UpdateApplicant
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