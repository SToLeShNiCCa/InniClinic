namespace Application.DTO.Receptionist
{
    public class UpdateReceptionistDTO
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
    }
}
