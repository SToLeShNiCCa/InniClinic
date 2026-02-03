namespace Application.DTO.Patients
{
    public class ReadPatientDTO
    {
        public int Id { get; set; }
        /// <summary>
        /// Patient's first name.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Patient's last name.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Patient's middle name.
        /// </summary>
        public required string MiddleName { get; set; }

        /// <summary>
        /// Patient's date of birthday.
        /// </summary>
        public DateOnly DateOfBirth { get; set; }
    }
}
