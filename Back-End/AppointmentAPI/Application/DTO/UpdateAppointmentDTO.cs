namespace Application.DTO
{
    public class UpdateAppointmentDTO
    {
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool IsApproved { get; set; }
    }
}
