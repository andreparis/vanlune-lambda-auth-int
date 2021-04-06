using Amazon.Lambda.Core;
using Auth.Int.Application.Application.Base;
using Auth.Int.Domain.Entities;
using System;

namespace Auth.Int.Application.Application.Services
{
    public static class UserService
    {
        public static AuthPolicyBuilder Validade(string token, 
            string method,
            ILambdaLogger logger)
        {
            try
            {
                var methodArn = ApiGatewayArn.Parse(method);
                var apiOptions = new ApiOptions(methodArn.Region, methodArn.RestApiId, methodArn.Stage);

                var policyBuilder = new AuthPolicyBuilder("", methodArn.AwsAccountId, apiOptions);

                var isValid = token.Equals("7793B690-9EC7-4240-A152-1D3046693CB3");

                if (isValid)
                    policyBuilder.AllowMethod(new HttpVerb(methodArn.Verb), methodArn.Resource);
                else
                    policyBuilder.DenyMethod(new HttpVerb(methodArn.Verb), methodArn.Resource);

                return policyBuilder;
            }
            catch(Exception e)
            {
                logger.LogLine($"Error {e.Message} at {e.StackTrace}");

                return default;
            }
        }
    }
}
