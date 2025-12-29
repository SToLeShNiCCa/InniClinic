namespace Application.DTO
{
    public class ReadAppointmentDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public bool IsApproved { get; set; }
    }
}
