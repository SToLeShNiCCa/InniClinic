using Application.DTO.ResultDTO;
using FluentValidation;

namespace Application.Validator
{
    public class CreateResultDTOValidator : AbstractValidator<CreateResultDTO>
    {
        public CreateResultDTOValidator()
        {
            RuleFor(x => x.Complaints)
                .NotEmpty()
                .MaximumLength(1024);

            RuleFor(x => x.Conclusion)
                .NotEmpty()
                .MaximumLength(1024);

            RuleFor(x => x.Recommendations)
                .NotEmpty()
                .MaximumLength(1024);

            RuleFor(x => x.AppointmentId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
