namespace Domain.Models
{
    public class ServiceCategory : Entity
    {
        public required string CategoryName { get; set; }

        public required string TimeSlotSize { get; set; }

        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
