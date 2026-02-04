using Application.DTO;
using FluentValidation;

namespace Application.Validator;

public class UpdateOfficeDTOValidator : AbstractValidator<UpdateOfficeDTO>
{
    public UpdateOfficeDTOValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(x => x.PhotoID)
            .NotEmpty();

        RuleFor(x => x.RegistryPhoneNumber)
            .NotEmpty()
            .MaximumLength(32);
    }
}
