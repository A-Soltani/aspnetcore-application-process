using Hahn.ApplicationProcess.December2020.Domain.Exceptions;
using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate
{
    public class Applicant : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public int Age { get; private set; }
        public string EmailAddress { get; private set; }
        public Address Address { get; private set; }

        public bool Hired { get; private set; }

        public Applicant()
        {
        }

        private Applicant(string name, string familyName, int age, string emailAddress, Address address, bool hired)
        {
            Name = name;
            FamilyName = familyName;
            Age = age;
            EmailAddress = emailAddress;
            Address = address;
            Hired = hired;
        }

        public static Applicant AddApplicant(string name, string familyName, int age, string emailAddress, Address address) => 
            new Applicant(name, familyName, age, emailAddress, address, false);

        public void Update(string name, string familyName, int age, string emailAddress, Address address)
        {
            if (Hired)
                throw new ApplicationProcessDomainException("This applicant could not be changed because it has been accepted!");

            Name = name;
            FamilyName = familyName;
            Age = age;
            EmailAddress = emailAddress;
            Address = address;
        }

        public void Hire() => Hired = true;
    }
}