using Application.DTO;
using FluentValidation;

namespace Application.Validator;

public class CreateAppointmentDTOValidator : AbstractValidator<CreateAppointmentDTO>
{
    public CreateAppointmentDTOValidator()
    {
        RuleFor(x => x.PatientId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.DoctorId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.ServiceId)
            .NotNull()
            .GreaterThan(0);
    }
}
