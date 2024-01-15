namespace DFC.Common.SharedContent.Pkg.Netcore.Model
{
    /// <summary>
    /// The cache response class.
    /// </summary>
    /// <typeparam name="TData">The type of the data.</typeparam>
    public class CacheRepoResponse<TData>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public TData Data { get; set; }

        /// <summary>
        /// Gets or sets the meta data.
        /// </summary>
        /// <value>
        /// The meta data.
        /// </value>
        public CacheMetaData MetaData { get; set; }
    }
}
