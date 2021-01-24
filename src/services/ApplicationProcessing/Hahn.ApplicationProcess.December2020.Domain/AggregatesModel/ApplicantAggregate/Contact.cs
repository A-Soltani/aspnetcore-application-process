using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate
{
    public class Contact : Entity
    {
        public string EmailAddress { get; private set; }
        public Address Address { get; private set; }

        public Contact(string emailAddress, Address address)
        {
            EmailAddress = emailAddress;
            Address = address;
        }
    }
}