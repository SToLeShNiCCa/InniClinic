using Application.DTO.ServiceCategoryDTO;
using FluentValidation;

namespace Application.DTO.Validator.ServiceCategoryValidator;

public class CreateServiceCategoryDTOValidator : AbstractValidator<CreateServiceCategoryDTO>
{
    public CreateServiceCategoryDTOValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(x => x.TimeSlotSize)
            .NotEmpty()
            .MaximumLength(11);
    }
}
