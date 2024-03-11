using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure
{
    public class HealthCheck : IHealthCheck
    {
        private readonly IConnectionMultiplexer redis;

        public HealthCheck(IConnectionMultiplexer redisCache)
        {
            redis = redisCache;
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

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
