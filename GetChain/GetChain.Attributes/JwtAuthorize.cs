using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using GetChain.Core.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace GetChain.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class JwtAuthorize : AuthorizeAttribute, IAsyncActionFilter {

        private static readonly ContentResult ApiKeyNotProvided = new() {
            StatusCode = StatusCodes.Status401Unauthorized,
            Content = "API Key was not provided"
        };
        
        private static readonly ContentResult ApiKeyNotValid = new() {
            StatusCode = StatusCodes.Status401Unauthorized,
            Content = "API Key was not valid"
        };
        
        private static readonly ContentResult NoUser = new() {
            StatusCode = StatusCodes.Status401Unauthorized,
            Content = "No authorization header found. Please supply a valid 'Authorization' header."
        };
        
        public JwtAuthorize() => AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;

        public JwtAuthorize(string policy) : base(policy) =>
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            if ( !context.HttpContext.Request.Headers.TryGetValue("Authorization", out var extractedApiKey) ) {
                context.Result = ApiKeyNotProvided;
                return;
            }

            var userManager = context.HttpContext.RequestServices.GetService<IAppUserManager>();
            if ( userManager != null ) {
                var user = await userManager.GetUserByIdAsync(context.HttpContext.User.GetUniqueId());
                if ( user == null ) {
                    context.Result = NoUser;
                    return;
                }

                if ( !user.ApiKeys.Any(x => extractedApiKey.Any(key => x.Key == key.Substring(7))) ) {
                    context.Result = ApiKeyNotValid;
                    return;
                }
            }

            await next();
        }
    }
}