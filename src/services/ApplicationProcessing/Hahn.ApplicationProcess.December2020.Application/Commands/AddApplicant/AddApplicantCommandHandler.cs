﻿using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant
{
    public class AddApplicantCommandHandler : IRequestHandler<AddApplicantCommand, int>
    {
        private readonly ICountryClient _countryClient;

        private readonly IApplicantRepository _applicantRepository;

        public AddApplicantCommandHandler(ICountryClient countryClient, IApplicantRepository applicantRepository)
        {
            _countryClient = countryClient ?? throw new ArgumentNullException(nameof(countryClient));
            _applicantRepository = applicantRepository ?? throw new ArgumentNullException(nameof(applicantRepository));
        }

        public async Task<int> Handle(AddApplicantCommand request, CancellationToken cancellationToken)
        {
            // ToDo costume ruleFor
            await ValidateCountry(request.CountryOfOrigin);

            var address = new Address(request.City, request.CountryOfOrigin);
            var applicant = Applicant.AddApplicant(request.Name, request.FamilyName, request.Age, request.EmailAddress, address);

            await _applicantRepository.Add(applicant);
            await _applicantRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return applicant.Id;
        }

        private async Task ValidateCountry(string countryOfOrigin)
        {
            //ToDo Cash api county valid list valid country
            var response = await _countryClient.GetCountry(countryOfOrigin);
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new ValidationException($"There is no country named {countryOfOrigin}");
        }


    }
}