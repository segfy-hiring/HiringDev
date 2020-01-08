namespace WebServices.Infra.Models
{
    /// <summary>
    /// Contract to entities that will  have IIdentifiable
    /// </summary>
    /// <typeparam name="IDType">
    /// Identifier type.
    /// </typeparam>
    public interface IIdentifiable<IDType>
    {
        /// <summary>
        /// Identifier
        /// </summary>
        IDType Id { get; set; }
    }
}