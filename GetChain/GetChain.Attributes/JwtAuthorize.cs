using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using GetChain.Core.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace GetChain.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class JwtAuthorize : AuthorizeAttribute, IAsyncActionFilter {

        public JwtAuthorize() => AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;

        public JwtAuthorize(string policy) : base(policy) =>
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            if ( !context.HttpContext.Request.Headers.TryGetValue("Authorization", out var extractedApiKey) ) {
                context.Result = new ContentResult() {
                    StatusCode = 401,
                    Content = "API Key was not provided"
                };
                return;
            }

            var userManager = context.HttpContext.RequestServices.GetService<IAppUserManager>();
            if ( userManager != null ) {
                var user = await userManager.GetUserByIdAsync(context.HttpContext.User.GetUniqueId());
                if ( !user.ApiKeys.Any(x => extractedApiKey.Any(key => x.Key == key.Substring(7))) ) {
                    context.Result = new ContentResult() {
                        StatusCode = 401,
                        Content = "Api Key is not valid"
                    };
                    return;
                }
            }

            await next();
        }
    }
}