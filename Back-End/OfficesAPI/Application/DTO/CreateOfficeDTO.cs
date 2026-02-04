namespace Application.DTO
{
    public class CreateOfficeDTO
    {
        public string Address { get; set; } = default!;
        public string PhotoID { get; set; } = default!;
        public string RegistryPhoneNumber { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
