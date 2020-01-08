namespace WebServices.API.NetCore
{
    using System.Linq;
    using System.Threading.Tasks;
    using WebServices.Infra.Exceptions;
    using FluentValidation;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// ValidateThrowingExceptionAsync.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="validator">validator.</param>
        /// <param name="instance">instance.</param>
        /// <param name="errorCode">errorCode.</param>
        /// <param name="errorMessage">errorMessage.</param>
        /// <returns>Task</returns>
        public static async Task ValidateThrowingExceptionAsync<T>(this IValidator<T> validator, T instance, object errorCode, string errorMessage)
        {
            ThrowExceptionIfInvalid(
                errorCode: errorCode.ToString(),
                errorMessage: errorMessage,
                validationResult: await validator.ValidateAsync<T>(instance));
        }

        /// <summary>
        /// AddErrorToModelState
        /// </summary>
        /// <param name="code">code.</param>
        /// <param name="description">description.</param>
        /// <param name="modelState">modelState.</param>
        /// <returns>ModelStateDictionary</returns>
        public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
            modelState.TryAddModelError(code, description);
            return modelState;
        }

        /// <summary>
        /// ThrowExceptionIfInvalid.
        /// </summary>
        /// <param name="errorCode">errorCode.</param>
        /// <param name="errorMessage">errorMessage.</param>
        /// <param name="validationResult">validationResult;</param>
        internal static void ThrowExceptionIfInvalid(string errorCode, string errorMessage, ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return;
            }

            var exception = new IntegraException(new ValidationInfo(errorCode, errorMessage));

            foreach (var item in validationResult.Errors.GroupBy(t => t.PropertyName))
            {
                exception.Fields.Add(item.Key, item.Select(t => t.ErrorMessage).ToList());
            }

            throw exception;
        }
    }
}