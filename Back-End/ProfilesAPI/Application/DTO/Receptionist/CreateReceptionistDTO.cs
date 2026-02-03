namespace Application.DTO.Receptionist
{
    /// <summary>
    /// Data Transfer Object (DTO) for Receptionist entity.
    /// </summary>
    public class CreateReceptionistDTO
    {
        /// <summary>
        /// Receptionist's first name.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Receptionist's last name.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Receptionist's middle name.
        /// </summary>
        public required string MiddleName { get; set; }

        /// <summary>
        /// Office identifier associated with the receptionist(foreign key).
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Account identifier associated with the receptionist(foreign key).
        /// </summary>
        public int AccountId { get; set; }
    }
}
