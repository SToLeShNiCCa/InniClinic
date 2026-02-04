using Application.DTO;
using FluentValidation;

namespace Application.Validator;

public class UpdateAppointmentDTOValidator : AbstractValidator<UpdateAppointmentDTO>
{
    public UpdateAppointmentDTOValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.ServiceId)
            .NotNull()
            .GreaterThan(0);
    }
}
