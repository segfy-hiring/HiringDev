namespace WebServices.Infra.Exceptions
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// Validation Info.
    /// </summary>
    public class ValidationInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationInfo"/> class.
        /// Constructor that receives message with "|" and split mesage.
        /// </summary>
        /// <param name="message">Message with "|".</param>
        public ValidationInfo(string message)
        {
            var messageCode = message.Split('|');
            if (messageCode.Length > 1)
            {
                Id = messageCode.First();
                Message = messageCode.Last();
            }
            else
            {
                Message = message;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationInfo"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="message">Message.</param>
        public ValidationInfo(string code, string message)
        {
            Id = code;
            Message = message;
        }

        /// <summary>
        /// Gets or sets Message code.
        /// </summary>
        /// <value>
        /// Message code.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        /// <value>
        /// Message description.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Get message validation from resources files.
        /// </summary>
        /// <param name="t">Assembly type.</param>
        /// <param name="code">Message code.</param>
        /// <returns>Validation message.</returns>
        public static ValidationInfo GetErrorMessage(Type t, string code)
        {
            Assembly assembly = t.Assembly;

            var name = t.Assembly.GetName().Name;
            var resman = new ResourceManager(name + ".Properties." + t.Name + "Resources", assembly);
            string strClientName = resman.GetString(code);

            if (string.IsNullOrEmpty(strClientName))
            {
                var msg = string.Format("Error code '{0}' not implemented in resources", code);
                throw new ArgumentNullException(code, msg);
            }

            return new ValidationInfo(code, strClientName);
        }

        /// <summary>
        /// Get message validation from resources files and replace information.
        /// </summary>
        /// <param name="t">Assembly type.</param>
        /// <param name="code">Message code.</param>
        /// <param name="args">Args to be changed.</param>
        /// <returns>Validation message.</returns>
        public static ValidationInfo GetMensagemErro(Type t, string code, params object[] args)
        {
            var validationMessage = GetErrorMessage(t, code);

            validationMessage.Message = string.Format(validationMessage.Message, args);

            return validationMessage;
        }

        /// <summary>
        /// Internal server error.
        /// </summary>
        /// <returns>Validation Info.</returns>
        public static ValidationInfo GetInternalServerErrorValidationInfo()
        {
            return new ValidationInfo("INTERNAL0001", "Internal Server error");
        }
    }
}