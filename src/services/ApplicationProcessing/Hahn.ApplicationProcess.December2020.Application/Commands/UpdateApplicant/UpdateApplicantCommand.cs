using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.UpdateApplicant
{
    public class UpdateApplicantCommand : IRequest<bool>
    {
        public int ApplicantId { get; set; }
        /// <example>Dear Ali</example>
        public string Name { get; set; }
        /// <example>Soltani</example>
        public string FamilyName { get; set; }
        /// <example>38</example>
        public int Age { get; set; }
        /// <example>soltani1380@gmail.com</example>
        public string EmailAddress { get; set; }
        /// <example>IRAN</example>
        public string CountryOfOrigin { get; set; }
        /// <example>Tehran</example>
        public string City { get; set; }
        /// <example>IRAN, Tehran, 8 South Narmak</example>
        public string FullAddress { get; set; }
    }
}