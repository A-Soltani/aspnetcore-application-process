
using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using ApplicationProcess.Domain.Exceptions;
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

            Assert.Throws<ApplicationProcessDomainException>(() => fakeApplicant.Update("Test", "Test Family", 30, "test@test.com", new Address()));
        }

        private Applicant GetFakeApplicant() => 
            Applicant.AddApplicant("Test", "Test Family", 30, "test@test.com", new Address());
    }
}