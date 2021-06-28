using System;
using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using GetChain.Core.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GetChain {
    public class Startup {
        
        public Startup(IConfiguration configuration) {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddControllers();

            services.AddDataProtection();

            // set up services
            services.AddAuthentication()
                .AddCookie(opt => {
                    opt.LoginPath = new PathString("/Login");
                    opt.LogoutPath = new PathString("/Logout");
                    opt.AccessDeniedPath = new PathString("/AccessDenied");
                })
                .AddJwtBearer();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigureMongoDbIdentity<ApplicationUser, ApplicationRole, Guid>(new MongoDbIdentityConfiguration {
                MongoDbSettings = new MongoDbSettings {
                    ConnectionString = this._configuration.GetConnectionString("DatabaseConnectionString"),
                    DatabaseName = "GetChainDatabase"
                },
                IdentityOptionsAction = options => {
                    // ApplicationUser settings
                    options.User.RequireUniqueEmail = true;
                }
            });

            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddBscScanner(opt => opt.ApiKey = _configuration.GetSection("ApiKeys:BscScanKey").Value);
            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "GetChain", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if ( env.IsDevelopment() ) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptAPI v1");
                // c.RoutePrefix = "api/v1";
            });
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}