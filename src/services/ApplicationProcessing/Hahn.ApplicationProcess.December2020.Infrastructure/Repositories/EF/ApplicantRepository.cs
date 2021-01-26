using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Infrastructure.Repositories.EF
{
    public class ApplicantRepository: IApplicantRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<Applicant> Add(Applicant applicant)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Applicant applicant)
        {
            throw new System.NotImplementedException();
        }

        public Task<Applicant> Get(int applicantId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Applicant> Delete(int applicantId)
        {
            throw new System.NotImplementedException();
        }
    }
}