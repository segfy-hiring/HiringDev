namespace WebServices.Infra
{
    using WebServices.Infra.ErrorHandler;
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// Extensions.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// UseErrorReturnExceptionHandler
        /// </summary>
        /// <param name="app">app.</param>
        /// <param name="showDetailedError">showDetailedError.</param>
        public static void UseErrorReturnExceptionHandler(this IApplicationBuilder app, bool showDetailedError)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(ErrorReturnExceptionHandler.ExceptionHandlerDelegate(showDetailedError));
            });
        }
    }
}
