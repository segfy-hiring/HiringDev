namespace WebServices.IntegrationTests.Infra
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WebServices.Domain.Models;

    /// <summary>
    /// OdataResult. Object to paser odata result.
    /// </summary>
    public class OdataResult
    {
        /// <summary>
        /// OdataContext
        /// </summary>
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        /// <summary>
        /// Result data.
        /// </summary>
        [JsonProperty("value")]
        public List<YoutubeData> Value { get; set; }
    }
}
