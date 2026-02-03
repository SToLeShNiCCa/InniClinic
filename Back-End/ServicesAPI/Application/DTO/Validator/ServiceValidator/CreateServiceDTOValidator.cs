using Application.DTO.ServiceDTO;
using FluentValidation;

namespace Application.DTO.Validator.ServiceValidator;

public class CreateServiceDTOValidator : AbstractValidator<CreateServiceDTO>
{
    public CreateServiceDTOValidator()
    {
        RuleFor(x => x.ServiceCategoryId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.ServiceName)
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(x => x.Price)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.SpecializationId)
            .NotNull()
            .GreaterThan(0);

    }
}
