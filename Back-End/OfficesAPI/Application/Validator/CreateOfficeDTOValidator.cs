using Application.DTO;
using FluentValidation;

namespace Application.Validator;

public class CreateOfficeDTOValidator : AbstractValidator<CreateOfficeDTO>
{
    public CreateOfficeDTOValidator()
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
