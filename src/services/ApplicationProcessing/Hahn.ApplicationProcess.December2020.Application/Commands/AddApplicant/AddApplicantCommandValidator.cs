using System;
using System.Threading;
using FluentValidation;
using Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant
{
    public class AddApplicantCommandValidator : AbstractValidator<AddApplicantCommand>
    {
        private readonly ICountryService _countryService;
        public AddApplicantCommandValidator(ICountryService countryService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));

            RuleFor(applicant => applicant.Age)
                .NotNull()
                .WithMessage("Age is required")
                .InclusiveBetween(20, 60)
                .WithMessage("Age must be between 20 and 60");
            RuleFor(applicant => applicant.City)
                .NotEmpty()
                .WithMessage("City is required");

            RuleFor(x => x.CountryOfOrigin)
                .NotEmpty()
                .WithMessage("CountryOfOrigin is required")
                .MustAsync(async (countryName, cancellation) => await _countryService.CountryExists(countryName))
                .WithMessage("Country not found.");

            RuleFor(dto => dto.EmailAddress)
                .NotEmpty().
                WithMessage("Email Address is required")
                .EmailAddress()
                .WithMessage("Invalid Email Address Format");
            RuleFor(applicant => applicant.FamilyName)
                .NotEmpty()
                .WithMessage("FamilyName is required")
                .MinimumLength(5)
                .WithMessage("Family Name must be at least 5 Characters");
            RuleFor(applicant => applicant.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(5)
                .WithMessage("Name must be at least 5 Characters");
            RuleFor(applicant => applicant.FullAddress)
                .NotEmpty()
                .WithMessage("FullAddress is required")
                .MinimumLength(5)
                .WithMessage("Full address must be at least 10 Characters");
        }
    }
}