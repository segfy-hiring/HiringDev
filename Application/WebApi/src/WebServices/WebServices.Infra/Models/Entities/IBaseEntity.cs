namespace WebServices.Infra.Models
{
    /// <summary>
    /// Contract to indicate that class is an entity.
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Identifier
        /// </summary>
        object Id { get; }
    }
}