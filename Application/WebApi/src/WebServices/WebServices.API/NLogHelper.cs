namespace WebServices.API
{
    using NLog;
    using NLog.Config;

    /// <summary>
    /// Class used to create log instance.
    /// </summary>
    public static class NLogHelper
    {
        /// <summary>
        /// Get Logger.
        /// </summary>
        /// <returns>Logger.</returns>
        public static Logger GetLogger()
        {
            // Step 1. Create configuration object.
            return NLog.Web.NLogBuilder.ConfigureNLog("NLOG.config").GetCurrentClassLogger();
        }
    }
}
