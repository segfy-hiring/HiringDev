namespace WebServices.Infra.OData.ErrorHandler
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using WebServices.Infra.ErrorHandler;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Formatter;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.OData;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /*
     * https://stackoverflow.com/questions/51491011/is-there-a-way-to-handle-asp-net-core-odata-errors
     */

    /// <summary>
    /// ErrorReturnODataOutputFormatter.
    /// </summary>
    public class ErrorReturnODataOutputFormatter : ODataOutputFormatter
    {
        private readonly JsonSerializer serializer;
        private readonly bool showDetailedError;

        /// <summary>
        /// ErrorReturnODataOutputFormatter.
        /// </summary>
        /// <param name="showDetailedError">showDetailedError.</param>
        public ErrorReturnODataOutputFormatter(bool showDetailedError)
            : base(new[] { ODataPayloadKind.Error })
        {
            this.serializer = new JsonSerializer { ContractResolver = new DefaultContractResolver() };
            this.showDetailedError = showDetailedError;

            this.SupportedMediaTypes.Add("application/json");
            this.SupportedEncodings.Add(new UTF8Encoding());
        }

        /// <summary>
        /// WriteResponseBodyAsync.
        /// </summary>
        /// <param name="context">context.</param>
        /// <param name="selectedEncoding">selectedEncoding.</param>
        /// <returns>Task.</returns>
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (!(context.Object is SerializableError serializableError))
            {
                return base.WriteResponseBodyAsync(context, selectedEncoding);
            }

            using (var writer = new StreamWriter(context.HttpContext.Response.Body))
            {
                this.serializer.Serialize(writer, TransformToErrorReturn(serializableError, showDetailedError));
                return writer.FlushAsync();
            }
        }

        /// <summary>
        /// TransformToErrorReturn.
        /// </summary>
        /// <param name="serializableError">serializableError.</param>
        /// <param name="showDetailedError">showDetailedError.</param>
        /// <returns>ErrorReturn.</returns>
        private static ErrorReturn TransformToErrorReturn(SerializableError serializableError, bool showDetailedError)
        {
            // ReSharper disable once InvokeAsExtensionMethod
            var convertedError = SerializableErrorExtensions.CreateODataError(serializableError);
            ErrorReturn errorReturn = null;

            if (showDetailedError)
            {
                errorReturn = new ErrorReturn(convertedError.Message);

                var innerError = convertedError.InnerError;
                var index = 0;
                while (innerError != null)
                {
                    var indexer = index == 0 ? string.Empty : index.ToString();

                    errorReturn.ValidationFields.Add($"{indexer}Message", new List<string> { innerError.Message });
                    errorReturn.ValidationFields.Add($"{indexer}StackTrace", new List<string> { innerError.StackTrace });
                    errorReturn.ValidationFields.Add($"{indexer}TypeName", new List<string> { innerError.TypeName });

                    innerError = innerError.InnerError;
                    index++;
                }
            }
            else
            {
                // Sanitise the exposed data when in release mode.
                // We do not want to give the public access to stack traces, etc!
                errorReturn = new ErrorReturn(ErrorReturn.DefaultErrorMessage);

                errorReturn.ValidationFields.Add("Message", new List<string> { convertedError.Message });
            }

            return errorReturn;

        }
    }
}
