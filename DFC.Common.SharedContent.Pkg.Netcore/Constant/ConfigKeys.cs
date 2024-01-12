using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Constant
{
    public class ConfigKeys
    {
        /// <summary>
        /// The redis cache enabled.
        /// </summary>
        public const string RedisCacheEnabled = "RedisCache:CacheEnabled";

        /// <summary>
        /// The redis cache key prefix. Used only in debug mode for local environmet cache key conflict.
        /// </summary>
        public const string RedisCacheKeyPrefix = "RedisCache:CacheKeyPrefix";

        /// <summary>
        /// The token end point URL.
        /// </summary>
        public const string TokenEndPointUrl = "Cms:TokenEndPointUrl";

        /// <summary>
        /// The client identifier.
        /// </summary>
        public const string ClientId = "Cms:ClientId";

        /// <summary>
        /// The client secret.
        /// </summary>
        public const string ClientSecret = "Cms:ClientSecret";
        /// <summary>
        /// The API Url for the CMS.
        /// </summary>
        public const string GraphApiUrl = "Cms:GraphApiUrl";

        public const string SqlApiUrl = "Cms:SqlApiUrl";
    }
}
