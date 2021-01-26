using FluentValidation;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant
{
    public class AddApplicantCommandValidator : AbstractValidator<AddApplicantCommand>
    {
        public AddApplicantCommandValidator()
        {
            RuleFor(applicant => applicant.Age)
                .NotNull()
                .WithMessage("Age is required")
                .InclusiveBetween(20, 60)
                .WithMessage("Age must be between 20 and 60");
            RuleFor(applicant => applicant.City)
                .NotEmpty()
                .WithMessage("City is required");
            RuleFor(applicant => applicant.CountryOfOrigin)
                .NotEmpty()
                .WithMessage("CountryOfOrigin is required");
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