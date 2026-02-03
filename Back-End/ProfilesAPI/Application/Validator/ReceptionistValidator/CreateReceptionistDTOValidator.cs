using Application.DTO.Receptionist;
using FluentValidation;

namespace Application.Validator.ReceptionistValidator;

public class CreateReceptionistDTOValidator : AbstractValidator<CreateReceptionistDTO>
{
    public CreateReceptionistDTOValidator()
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

        RuleFor(x => x.OfficeId)
            .NotNull()
            .GreaterThan(0);
    }
}
