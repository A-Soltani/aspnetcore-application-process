using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationProcess.Domain.SeedWork;

namespace ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<Applicant> Add(Applicant applicant);
        void Update(Applicant applicant);
        Task<Applicant> Get(int applicantId);
        Task<IEnumerable<Applicant>> GetList();
        void Delete(Applicant applicant);
    }
}