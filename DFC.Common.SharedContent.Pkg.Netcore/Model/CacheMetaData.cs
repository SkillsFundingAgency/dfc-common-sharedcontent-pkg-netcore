﻿using DFC.Common.SharedContent.Pkg.Netcore.Enum;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model
{
    /// <summary>
    /// Model to store cache meta data information.
    /// </summary>
    public class CacheMetaData
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is cache enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cache enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCacheEnabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        /// <value>
        /// The expires.
        /// </value>
        public DateTime Expires { get; set; }

        /// <summary>
        /// Gets or sets the cache action.
        /// </summary>
        /// <value>
        /// The cache action.
        /// </value>
        public CacheActionEnum CacheAction { get; set; } = CacheActionEnum.None;
    }
}