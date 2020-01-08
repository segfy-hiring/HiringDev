namespace WebServices.Infra.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Equality entity comparer.
    /// </summary>
    /// <typeparam name="IDType">id type</typeparam>
    public class IdentifiableEqualityComparer<IDType> : IEqualityComparer<IIdentifiable<IDType>>
    {
        /// <summary>
        /// IIdentifiable
        /// </summary>
        /// <param name="x">param1</param>
        /// <param name="y">param2</param>
        /// <returns>return bool</returns>
        public bool Equals(IIdentifiable<IDType> x, IIdentifiable<IDType> y)
        {
            return x.Id.Equals(y.Id);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <param name="obj">The Obj</param>
        /// <returns>return hash code</returns>
        public int GetHashCode(IIdentifiable<IDType> obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}