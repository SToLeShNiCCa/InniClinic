namespace Application.DTO.Doctors
{
    public class UpdateDoctorDTO
    {
        /// <summary>
        /// Doctor's first name.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Doctor's last name.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Doctor's middle name.
        /// </summary>
        public required string MiddleName { get; set; }

        /// <summary>
        /// Specialization identifier associated with the doctor(foreign key).
        /// </summary>
        public int SpecializationId { get; set; }

        /// <summary>
        /// Office identifier associated with the doctor(foreign key).
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Year when doctor started his career.
        /// </summary>
        public int CareerStartYear { get; set; }

        /// <summary>
        /// Doctor's status (e.g., Active, Inactive).
        /// </summary>
        public required string Status { get; set; }
    }
}
