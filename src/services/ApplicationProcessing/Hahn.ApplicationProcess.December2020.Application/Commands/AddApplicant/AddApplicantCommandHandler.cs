using System;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant
{
    public class AddApplicantCommandHandler: AsyncRequestHandler<AddApplicantCommand>
    {
        //private readonly IApplicantRepository _applicantRepository;

        //public AddApplicantCommandHandler(IApplicantRepository applicantRepository) => 
        //    _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));

        protected override Task Handle(AddApplicantCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}