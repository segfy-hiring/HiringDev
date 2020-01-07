namespace WebServices.Infra.Exceptions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// IntegraException.
    /// </summary>
    public class IntegraException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegraException"/> class.
        /// </summary>
        /// <param name="validationInfoMessage">message.</param>
        public IntegraException(ValidationInfo validationInfoMessage)
            : this(validationInfoMessage.Id.ToString(), null, validationInfoMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegraException"/> class.
        /// </summary>
        /// <param name="validationInfoMessage">message.</param>
        /// <param name="innerException">inner exception.</param>
        public IntegraException(ValidationInfo validationInfoMessage, Exception innerException)
            : this(validationInfoMessage.Id.ToString(), innerException, validationInfoMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegraException"/> class, with validation messages
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="validationInfoMessage">validation messages</param>
        public IntegraException(string message, ValidationInfo validationInfoMessage)
            : this(message, null, validationInfoMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegraException"/> class, with validation messages
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="innerException">inner exception.</param>
        /// <param name="validationInfoMessage">validation message.</param>
        public IntegraException(string message, Exception innerException, ValidationInfo validationInfoMessage)
            : base(message, innerException)
        {
            ValidationInfoMessage = validationInfoMessage;
            Fields = new Dictionary<string, List<string>>();
        }

        /// <summary>
        /// Gets validation messages.
        /// </summary>
        /// <value>
        /// Validation messages.
        /// </value>
        public ValidationInfo ValidationInfoMessage { get; private set; }

        /// <summary>
        /// Gets or sets validation Fields.
        /// </summary>
        /// <value>
        /// Validation Fields.
        /// </value>
        public Dictionary<string, List<string>> Fields { get; set; }
    }
}
