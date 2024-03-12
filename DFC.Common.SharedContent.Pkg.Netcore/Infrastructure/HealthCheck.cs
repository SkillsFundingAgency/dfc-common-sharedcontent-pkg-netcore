using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;
using System.Net;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure
{
    public class HealthCheck : IHealthCheck
    {
        private readonly IConnectionMultiplexer redis;
        private readonly IGraphQLClient client;

        public HealthCheck(IConnectionMultiplexer redisCache, IGraphQLClient client)
        {
            redis = redisCache;
            this.client = client;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                foreach (var endPoint in redis.GetEndPoints(configuredOnly: true))
                {
                    var server = redis.GetServer(endPoint);
                    if (server.ServerType != ServerType.Cluster)
                    {
                        await redis.GetDatabase().PingAsync();
                        await server.PingAsync();
                    }
                    else
                    {
                        var clusterInfo = await server.ExecuteAsync("CLUSTER", "INFO");
                        if (clusterInfo is object && !clusterInfo.IsNull)
                        {
                            if (!clusterInfo.ToString()!.Contains("cluster_state:ok"))
                            {
                                return new HealthCheckResult(context.Registration.FailureStatus, description: $"CLUSTER is not is healthy for endpoint {endPoint}");
                            }
                        }
                        else
                        {
                            return new HealthCheckResult(context.Registration.FailureStatus, description: $"CLUSTER unhealthy for endpoint {endPoint}");
                        }
                    }
                }

                if (GraphQlHealthCheckAsync().Result == HttpStatusCode.OK)
                {
                    return HealthCheckResult.Healthy();
                }
                else
                {
                    return new HealthCheckResult(context.Registration.FailureStatus, description: "GraphQl has returned unhealthy");
                }
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }

        private async Task<HttpStatusCode> GraphQlHealthCheckAsync()
        {
            string query = $@"
                        query MyQuery {{
                            sharedContent(first: 1) {{
                                content {{
                                    html
                                }}
                            }}
                        }}";

            var response = await client.SendQueryAsync<SharedHtmlResponse>(query);
            if (response.Data.SharedContent.Any())
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}
