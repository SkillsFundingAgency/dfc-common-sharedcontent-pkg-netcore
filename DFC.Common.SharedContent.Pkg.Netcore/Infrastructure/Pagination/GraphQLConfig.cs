namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination
{
    /// <summary>
    /// The GraphQL config.
    /// </summary>
    public class GraphQLConfig
    {
        /// <summary>
        /// Skip count token in queries.
        /// </summary>
        public const string SkipCountToken = "${SKIPCOUNT}";

        /// <summary>
        /// Pagination count token in queries.
        /// </summary>
        public const string PaginationCountToken = "${PAGINATIONCOUNT}";
    }
}
