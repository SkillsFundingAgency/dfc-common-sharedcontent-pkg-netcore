using AutoMapper;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.CompositeInterfaceModels.FindACourseClient;
using DFC.FindACourseClient;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileCurrentOpportunitiesCoursesStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<CourseResponse>
    {
        private readonly ICourseSearchApiService client;
        private readonly ILogger<PageUrlQueryStrategy> logger;

        public JobProfileCurrentOpportunitiesCoursesStrategy(ICourseSearchApiService client, ILogger<PageUrlQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<CourseResponse> ExecuteQueryAsync(string key, string filter, double expire = 48)
        {
            logger.LogInformation($"{nameof(JobProfileCurrentOpportunitiesCoursesStrategy)} -> ExecuteQueryAsync");
            var coursekeywords = string.Concat("/", key.Substring(key.LastIndexOf("/") + 1)).Replace("/", string.Empty);

            var courseresponse = new CourseResponse();
            if (!string.IsNullOrWhiteSpace(coursekeywords))
            {
                try
                {
                    var response = await client.GetCoursesAsync(coursekeywords, true).ConfigureAwait(false);

                    courseresponse.Courses = response?.ToList();
                }
                catch (Exception ex)
                {
                    var errorMessage = $"{nameof(JobProfileCurrentOpportunitiesCoursesStrategy)} had error: " + ex.Message;
                    logger.LogError(ex, errorMessage);
                    throw ex;
                }
            }

            return courseresponse;
        }
    }
}