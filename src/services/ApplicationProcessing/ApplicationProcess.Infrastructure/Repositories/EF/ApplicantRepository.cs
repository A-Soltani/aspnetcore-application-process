using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using ApplicationProcess.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace ApplicationProcess.Infrastructure.Repositories.EF
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicantContext _applicantContext;

        public IUnitOfWork UnitOfWork => _applicantContext;

        public ApplicantRepository(ApplicantContext context) =>
            _applicantContext = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Applicant> Add(Applicant applicant) =>
            (await _applicantContext.Applicants.AddAsync(applicant)).Entity;

        public void Update(Applicant applicant) => 
            _applicantContext.Entry(applicant).State = EntityState.Modified;

        public async Task<Applicant> Get(int applicantId) => 
            await _applicantContext.Applicants.FirstOrDefaultAsync(a => a.Id == applicantId);

        public async Task<IEnumerable<Applicant>> GetList() => 
            await _applicantContext.Applicants.ToListAsync();

        public void Delete(Applicant applicant) => 
            _applicantContext.Applicants.Remove(applicant);
    }
}