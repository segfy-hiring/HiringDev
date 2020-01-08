namespace WebServices.Infra.ErrorHandler
{
    using System;
    using System.Collections.Generic;
    using WebServices.Infra.Exceptions;

    /// <summary>
    /// Default class to error return
    /// </summary>
    public class ErrorReturn
    {
        public const string DefaultErrorMessage = "An error has occured";

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorReturn"/> class.
        /// </summary>
        /// <param name="message">Message</param>
        public ErrorReturn(string message)
        {
            Message = new ValidationInfo(message);
            ValidationFields = new Dictionary<string, List<string>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorReturn"/> class.
        /// </summary>
        /// <param name="exception">Objeto erro</param>
        public ErrorReturn(Exception exception)
        {
            if (exception is IntegraException)
            {
                var integraException = exception as IntegraException;
                Message = integraException.ValidationInfoMessage;
                ValidationFields = integraException.Fields;
            }
            else
            {
                Message = new ValidationInfo(exception.Message);
                ValidationFields = new Dictionary<string, List<string>>();
            }
        }

        /// <summary>
        /// Validation message.
        /// </summary>
        public ValidationInfo Message { get; set; }

        /// <summary>
        /// Validation fields.
        /// </summary>
        public Dictionary<string, List<string>> ValidationFields { get; set; }
    }
}