using FluentValidation;

namespace Hahn.ApplicationProcess.December2020.Application.Commands.DeleteApplicant
{
    public class DeleteApplicantCommandValidator : AbstractValidator<DeleteApplicantCommand>
    {
        public DeleteApplicantCommandValidator()
        {
            RuleFor(dto => dto.ApplicantId)
                .NotNull()
                .WithMessage("Applicant Id should not be empty")
                .LessThan(1)
                .WithMessage("Applicant Id is invalid");
        }
    }
}