using System;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Infrastructure.Repositories.EF
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicantContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ApplicantRepository(ApplicantContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Applicant> Add(Applicant applicant) =>
            (await _context.Applicants.AddAsync(applicant)).Entity;

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