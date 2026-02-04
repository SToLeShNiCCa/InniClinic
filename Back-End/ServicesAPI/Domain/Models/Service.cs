namespace Domain.Models
{
    public class Service : Entity
    {
        public int ServiceCategoryId { get; set; }
        public required string ServiceName { get; set; }
        public required decimal Price { get; set; }
        public int SpecializationId { get; set; }
        public bool IsActive { get; set; }

        public required ServiceCategory ServiceCategory { get; set; }
    }
}
