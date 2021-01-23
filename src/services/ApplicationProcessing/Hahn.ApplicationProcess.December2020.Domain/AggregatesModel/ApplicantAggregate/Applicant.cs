using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate
{
    public class Applicant : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public Address Address { get; private set; }
        public string CountryOfOrigin { get; private set; }
        public string EmailAddress { get; private set; }
        public int Age { get; private set; }
        public bool Hired { get; private set; }

    }
}