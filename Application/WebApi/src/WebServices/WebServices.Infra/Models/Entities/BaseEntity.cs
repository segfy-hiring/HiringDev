namespace WebServices.Infra.Models
{
    #region Namespace imports

    using System;

    #endregion

    /// <summary>
    /// Generic Super-Class that identify all objects from domain.
    /// </summary>
    /// <typeparam name="IDType">
    /// IDentificador Type
    /// </typeparam>
    [Serializable]
    public abstract class BaseEntity<IDType> : IIdentifiable<IDType>, IBaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Entity identifier
        /// </summary>
        public virtual IDType Id { get; set; }

        /// <summary>
        /// Identifier
        /// </summary>
        object IBaseEntity.Id
        {
            get
            {
                return Id;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Check if the entities are equals using Id.
        /// </summary>
        /// <param name="other">
        /// Entity to be compared.
        /// </param>
        /// <returns>
        /// Is equals.
        /// </returns>
        public virtual bool Equals(BaseEntity<IDType> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other.Id, Id);
        }

        /// <summary>
        /// Check if the entities are equals using Id.
        /// </summary>
        /// <param name="other">
        /// Entity to be compared.
        /// </param>
        /// <returns>
        /// Is equals.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((BaseEntity<IDType>)obj);
        }

        /// <summary>
        /// Get Hash Code.
        /// </summary>
        /// <returns>HashCode Id</returns>
        public override int GetHashCode()
        {
            if (Id != null)
            {
                return Id.GetHashCode();
            }
            else
            {
                return new int().GetHashCode();
            }
        }

        /// <summary>
        /// Format output
        /// </summary>
        /// <returns>Text apresentation of entity</returns>
        public override string ToString()
        {
            return string.Format("Id: {0}", Id);
        }

        #endregion
    }
}