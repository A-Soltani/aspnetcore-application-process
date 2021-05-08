using FluentValidation;

namespace ApplicationProcess.Application.Queries.GetApplicant
{
    public class GetApplicantQueryValidator: AbstractValidator<GetApplicantQuery>
    {
        public GetApplicantQueryValidator()
        {
            RuleFor(query => query.ApplicantId)
                .LessThanOrEqualTo(0)
                .WithMessage("Applicant Id is invalid");
        }
    }
}