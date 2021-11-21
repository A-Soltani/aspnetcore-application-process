using FluentValidation;

namespace ApplicationProcess.Application.Commands.DeleteApplicant
{
    public class DeleteApplicantCommandValidator : AbstractValidator<DeleteApplicantCommand>
    {
        public DeleteApplicantCommandValidator()
        {
            RuleFor(dto => dto.ApplicantId)
                .NotNull()
                .WithMessage("Applicant Id should not be empty")
                .GreaterThan(1)
                .WithMessage("Applicant Id is invalid");
        }
    }
}