namespace Domain.DBServices.Interfaces
{
    /// <summary>
    /// Interface <c>IEntity</c> is used to define common properties for entities.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Identifier of the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// General field for all entites - First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// General field for all entites - Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// General field for all entites - Middle Name. // TODO
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// General foreign key for all entites.
        /// </summary>
        public int AccountId { get; set; }
    }
}
