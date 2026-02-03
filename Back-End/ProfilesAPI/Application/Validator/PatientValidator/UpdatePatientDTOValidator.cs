using Application.DTO.Patients;
using FluentValidation;

namespace Application.Validator.PatientValidator;

public class UpdatePatientDTOValidator : AbstractValidator<UpdatePatientDTO>
{
    public UpdatePatientDTOValidator()
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
    }
}
