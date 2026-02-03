using Application.DTO.Receptionist;
using FluentValidation;

namespace Application.Validator.ReceptionistValidator;

public class UpdateReceptionistDTOValidator : AbstractValidator<UpdateReceptionistDTO>
{
    public UpdateReceptionistDTOValidator()
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

        RuleFor(x => x.OfficeId)
            .NotNull()
            .GreaterThan(0);
    }
}
