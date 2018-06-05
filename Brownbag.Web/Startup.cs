using System;
using System.Security.Claims;
using AutoMapper;
using Brownbag.Data.Models;
using Brownbag.Web.Middleware;
using Brownbag.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Brownbag.Web {
    public class Startup {
        public Startup (IHostingEnvironment env) {
            IConfigurationBuilder builder = new ConfigurationBuilder ()
                .SetBasePath (env.ContentRootPath)
                .AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true)
                .AddJsonFile ($"appsettings.{env.EnvironmentName}.json", optional : false, reloadOnChange : true);
            this.Configuration = builder.Build ();
        }
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();

            services.AddDbContext<ApplicationDataContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("ApiDb")));
            services.AddIdentity<User, IdentityRole<Guid>> (options =>
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@/\\")
                .AddEntityFrameworkStores<ApplicationDataContext> ();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor> ();
            services.AddMvc ()
                .AddJsonOptions (options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver ();
                });

            services.AddKendo ();
            services.AddScoped<IBrownbagRoleProvider, BrownbagRoleProvider> ();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles (configuration => {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAutoMapper ();
            services.AddTransient<RolesAuthorizationMiddleware> ();

            services.AddAuthorization (options => {
                options.AddPolicy ("Admin",
                    policy => {
                        policy.RequireAuthenticatedUser ();
                        policy.RequireClaim (ClaimTypes.Role, "Admin");
                    });
            });
            services.Configure<IISOptions> (options => {
                options.AutomaticAuthentication = true;
            });
            services.AddAuthentication (IISDefaults.AuthenticationScheme);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            app.RolesAuthorization ();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseStaticFiles ();
            app.UseSpaStaticFiles ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa (spa => {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment ()) {
#if DEBUG
                    spa.UseProxyToSpaDevelopmentServer ("http://localhost:4200");
#endif
#if INTEGRATED || RELEASE
                    spa.UseAngularCliServer (npmScript: "start");
#endif
                }
            });
            app.UseAuthentication ();
        }
    }
}