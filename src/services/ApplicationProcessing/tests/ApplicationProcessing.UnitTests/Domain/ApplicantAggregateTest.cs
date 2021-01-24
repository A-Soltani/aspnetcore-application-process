using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Hahn.ApplicationProcess.December2020.Domain.Exceptions;
using Xunit;

namespace ApplicationProcessing.UnitTests.Domain
{
    public class ApplicantAggregateTest
    {
        [Fact]
        public void AddApplicant_AddingNewApplicant_HiredStatusShouldBeFalse()
        {
            var fakeApplicant = GetFakeApplicant();
            
            Assert.False(fakeApplicant.Hired);
        }

        [Fact]
        public void Update_ApplicantHasBeenHired_ExceptionShouldBeThrown()
        {
            var fakeApplicant = GetFakeApplicant();
            fakeApplicant.Hire();

            var fakePerson = GetFakePerson();
            var fakeContact = GetFakeContact();

            Assert.Throws<ApplicationProcessDomainException>(() => fakeApplicant.Update(fakePerson,fakeContact));
        }

        private Applicant GetFakeApplicant()
        {
            var fakePerson = GetFakePerson();
            var fakeContact = GetFakeContact();

            var fakeApplicant = Applicant.AddApplicant(fakePerson, fakeContact);
            return fakeApplicant;
        }

        private Person GetFakePerson() => 
            new Person("test", "test", "IRAN", 25);

        private Contact GetFakeContact()
        {
            var fakeAddress = new Address("test street", "test city", "Tehran", "IRAN", "+98");
            var fakeContact = new Contact("test@test.com", fakeAddress);
            return fakeContact;
        }

    }
}