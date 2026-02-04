namespace Application.DTO.ServiceCategoryDTO
{
    public class ReadServiceCategoryDTO
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public required string TimeSlotSize { get; set; }
    }
}
