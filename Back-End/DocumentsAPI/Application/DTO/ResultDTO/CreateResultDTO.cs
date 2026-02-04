namespace Application.DTO.ResultDTO
{
    public class CreateResultDTO
    {
        public string Complaints { get; set; } = default!;
        public string Conclusion { get; set; } = default!;
        public string Recommendations { get; set; } = default!;
        public int AppointmentId { get; set; }
    }
}
