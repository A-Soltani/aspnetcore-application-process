using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Xunit;

namespace ApplicationProcessing.UnitTests.Domain
{
    public class ApplicantAggregateTest
    {
        [Fact]
        public void AddApplicant_CreatingNewApplicant_hiredStatusShouldBeFalse()
        {
            var fakePerson = new Person("test", "test", "IRAN", 25);
            var fakeAddress = new Address("test street", "test city", "Tehran", "IRAN", "+98");
            var fakeContact = new Contact("test@test.com", fakeAddress);
            
            var applicant = Applicant.AddApplicant(fakePerson, fakeContact);
            
            Assert.False(applicant.Hired);
        }
    }
}