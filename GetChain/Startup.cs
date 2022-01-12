using System;
using System.IO;
using System.Reflection;
using System.Text;
using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using AspNetCoreHero.ToastNotification;
using GetChain.Core.User;
using GetChain.MailService;
using GetChain.SwaggerGen.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

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
            services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                // .AddCookie(opt => {
                //     opt.LoginPath = new PathString("/Login");
                //     opt.LogoutPath = new PathString("/Logout");
                //     opt.AccessDeniedPath = new PathString("/AccessDenied");
                // })
                .AddJwtBearer(x => {
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = this._configuration["Jwt:Issuer"],
                        ValidAudience = this._configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._configuration["Jwt:Secret"]))
                    };
                });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson();

            services.AddNotyf(options => {
                options.Position = NotyfPosition.TopRight;
                options.IsDismissable = true;
                options.DurationInSeconds = 5;
            });
            
            services.AddAntiforgery(options => {
                options.HeaderName = "XSRF-TOKEN";
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<MailSenderOptions>(this._configuration.GetSection(MailSenderOptions.Name));
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
            services.AddSingleton<IMailSender, MailSender>();
            // services.AddBscScanner(opt => opt.ApiKey = _configuration.GetSection("ApiKeys:BscScanKey").Value);
            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "GetChain", 
                    Version = "v1",
                    License = new OpenApiLicense {
                        Name = "MIT",
                        Url = new Uri("https://github.com/pippinmole/GetChain/blob/main/LICENSE")
                    }
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                
                c.DocumentFilter<LowercaseDocumentFilter>();
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

            app.UseCors(opt => {
                opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptAPI v1");
                c.RoutePrefix = "api/v1";
                c.DocExpansion(DocExpansion.None);
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