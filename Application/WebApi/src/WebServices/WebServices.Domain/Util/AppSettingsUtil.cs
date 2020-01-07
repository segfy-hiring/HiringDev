namespace WebServices.Domain.Util
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// AppSettingsUtil.
    /// </summary>
    public static class AppSettingsUtil
    {
        private static IConfiguration objConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettingsUtil"/> class.
        /// </summary>
        /// <param name="configuration">configuration.</param>
        public static void SetAppSettingsUtil(IConfiguration configuration)
        {
            objConfiguration = configuration;
        }

        /// <summary>
        /// Get value from appsettings.
        /// </summary>
        /// <param name="key">key to get in appsettings.</param>
        /// <returns>object.</returns>
        public static string GetStringValue(string key)
        {
            return objConfiguration.GetValue<string>(key);
        }
    }
}
