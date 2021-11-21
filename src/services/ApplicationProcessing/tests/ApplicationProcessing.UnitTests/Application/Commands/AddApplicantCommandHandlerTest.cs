using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using Moq;
using Xunit;

namespace ApplicationProcessing.UnitTests.Application.Commands
{
    public class AddApplicantCommandHandlerTest
    {
        private readonly Mock<IApplicantRepository> _applicantRepositoryMock;

        public AddApplicantCommandHandlerTest()
        {
            _applicantRepositoryMock = new Mock<IApplicantRepository>();
        }

        [Fact]
        public void NameOfMethod_Scenario_ExpectedBehavior()
        {
               
        }
        
    }
}