using Amazon.Lambda.Core;
using System;
using Auth.Int.Domain.Entities;
using Auth.Int.Application.Application.Services;
using Auth.Int.Domain.Validation;

namespace Auth.Int.Application
{
    public class Function
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public AuthPolicy FunctionHandler(TokenAuthorizerContext input, ILambdaContext context)
        {
            try
            {
                context.Logger.LogLine($"{nameof(input.Authorization)}: {input.Authorization}");
                context.Logger.LogLine($"{nameof(input.MethodArn)}: {input.MethodArn}");

                var policyBuilder = UserService
                    .Validade(input.Authorization, 
                    input.MethodArn,
                    context.Logger);

                var authResponse = policyBuilder.Build();

                return authResponse;
            }
            catch(Exception e)
            {
                if (e is UnauthorizedException)
                    throw;

                context.Logger.LogLine(e.ToString());

                throw new UnauthorizedException();
            }
        }
    }
}
