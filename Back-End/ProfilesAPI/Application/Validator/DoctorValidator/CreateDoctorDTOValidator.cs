using Application.DTO.Doctors;
using FluentValidation;

namespace Application.Validator.DoctorValidator;

public class CreateDoctorDTOValidator : AbstractValidator<CreateDoctorDTO>
{
    public CreateDoctorDTOValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(32);

        RuleFor(x => x.MiddleName)
            .NotEmpty()
            .MaximumLength(32);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(32);

        RuleFor(x => x.AccountId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.SpecializationId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.OfficeId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.CareerStartYear)
            .NotNull()
            .GreaterThan(1950);

        RuleFor(x => x.Status)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(8);
    }
}
