using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using System.Net;
using System;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class SharedHtmlQueryStrategy : ISharedContentRedisInterfaceStrategy<SharedHtml>
{
    public async Task<SharedHtml> ExecuteQueryAsync(string key)
    {
        //create query 
        //var response = await client.SendQueryAsync<TResponse>(query);
        //format response
        return await Task.FromResult(new SharedHtml
        {
            HtmlContent = "<legend class=\"govuk-fieldset__legend govuk-fieldset__legend--l\">\r\n            <h1 class=\"govuk-fieldset__heading\">Contact us</h1>\r\n        </legend>\r\n        <p>\r\n            Call @Model.PhoneNumber to speak to an adviser.\r\n        </p>\r\n        <p>\r\n            We're open:\r\n        </p>\r\n        <blockquote>\r\n            <ul class=\"govuk-list govuk-list--bullet\">\r\n                <li>\r\n                    <span class=\"govuk-body govuk-!-font-weight-bold\">8am to 8pm</span> Monday to Friday\r\n                </li>\r\n                <li>\r\n                    <span class=\"govuk-body govuk-!-font-weight-bold\">10am to 5pm</span> Saturday and <a class=\"govuk-link\" href=\"https://www.gov.uk/bank-holidays\">bank holidays</a>\r\n                </li>\r\n            </ul>\r\n        </blockquote>\r\n        <p class=\"govuk-body\">\r\n            We're closed Sunday, Christmas Day and New Year's Day.\r\n        </p>\r\n        <p class=\"govuk-body\">\r\n            Calls are free from landlines and most mobile numbers. Please check for <a class=\"govuk-link\" href=\"https://www.gov.uk/call-charges\">possible call charges and freephone numbers</a>.\r\n        </p>"
        });
    }
}