using System;
using ApplicationProcess.Infrastructure.ExternalServices.RestCountries;
using FluentValidation;

namespace ApplicationProcess.Application.Commands.UpdateApplicant
{
    public class UpdateApplicantCommandValidator : AbstractValidator<UpdateApplicantCommand>
    {
        private readonly ICountryService _countryService;
        public UpdateApplicantCommandValidator(ICountryService countryService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));

            RuleFor(dto => dto.ApplicantId)
                .NotNull()
                .WithMessage("Applicant Id should not be empty")
                .LessThan(1)
                .WithMessage("Applicant Id is invalid");

            RuleFor(dto => dto.Age)
                .NotNull()
                .WithMessage("Age is required")
                .InclusiveBetween(20, 60)
                .WithMessage("Age must be between 20 and 60");
            RuleFor(dto => dto.City)
                .NotEmpty()
                .WithMessage("City is required");
            RuleFor(dto => dto.CountryOfOrigin)
                .NotEmpty()
                .WithMessage("CountryOfOrigin is required")
                .MustAsync(async (countryName, cancellation) => await _countryService.CountryExists(countryName))
                .WithMessage($"Country not found.");
            RuleFor(dto => dto.EmailAddress)
                .NotEmpty().
                WithMessage("Email Address is required")
                .EmailAddress()
                .WithMessage("Invalid Email Address Format");
            RuleFor(dto => dto.FamilyName)
                .NotEmpty()
                .WithMessage("FamilyName is required")
                .MinimumLength(5)
                .WithMessage("Family Name must be at least 5 Characters");
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(5)
                .WithMessage("Name must be at least 5 Characters");
            RuleFor(dto => dto.FullAddress)
                .NotEmpty()
                .WithMessage("FullAddress is required")
                .MinimumLength(5)
                .WithMessage("Full address must be at least 10 Characters");
        }
    }
}