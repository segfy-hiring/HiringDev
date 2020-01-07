namespace WebServices.Infra.Models
{
    /// <summary>
    /// Validation enum
    /// </summary>
    public enum EnumValidationInfo
    {
        /// <summary>
        /// Entity not found.
        /// </summary>
        EntityNotFound = 98,

        /// <summary>
        /// Constraint conflict.
        /// </summary>
        ConflictedConstraint = 97,

        /// <summary>
        /// Invalid properties.
        /// </summary>
        ValidationError = 96,

        /// <summary>
        /// Conversion problems.
        /// </summary>
        ConversionError = 95,

        /// <summary>
        /// UploadSourceProjectNameHeaderNotPresent
        /// </summary>
        UploadSourceProjectNameHeaderNotPresent = 0
    }
}