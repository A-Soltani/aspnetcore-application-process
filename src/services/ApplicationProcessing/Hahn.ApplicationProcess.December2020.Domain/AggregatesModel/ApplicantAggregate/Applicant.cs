using Hahn.ApplicationProcess.December2020.Domain.Exceptions;
using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate
{
    public class Applicant : Entity, IAggregateRoot
    {
        public Person Person { get; private set; }
        public Contact Contact { get; private set; }
        public bool Hired { get; private set; }

        public Applicant(Person person, Contact contact, bool hired)
        {
            Person = person;
            Contact = contact;
            Hired = hired;
        }

        public static Applicant AddApplicant(Person person, Contact contact) => 
            new Applicant(person, contact, false);

        public void Update(Person person, Contact contact)
        {
            if (Hired)
                throw new ApplicationProcessDomainException("This applicant could not be changed because it has been accepted!");

            Person = person;
            Contact = contact;
        }

        public void Hire() => Hired = true;
    }
}