using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetChain.Core.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace GetChain.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ApiUsageAttribute : Attribute, IAsyncActionFilter {
        
        private static readonly ContentResult NoUser = new() {
            StatusCode = StatusCodes.Status401Unauthorized,
            Content = "No authorization header found. Please supply a valid 'Authorization' header."
        };

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            // if ( !context.HttpContext.Request.Headers.TryGetValue("Authorization", out var extractedApiKey) ) {
            //     context.Result = ApiKeyNotProvided;
            //     return;
            // }
            
            var userManager = context.HttpContext.RequestServices.GetService<IAppUserManager>();
            if ( userManager != null ) {
                var user = await userManager.GetUserByIdAsync(context.HttpContext.User.GetUniqueId());
                if ( user == null ) {
                    context.Result = NoUser;
                    return;
                }
                
                user.ApiUsages ??= new List<ApiUsage>();
                user.ApiUsages.Add(new ApiUsage(
                    DateTime.Now
                ));

                await userManager.UpdateUserAsync(user);
            }

            await next();
        }
        
    }
}