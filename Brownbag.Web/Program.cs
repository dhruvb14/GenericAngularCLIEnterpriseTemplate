using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Brownbag.Data.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Brownbag.Web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                // Retrieve your DbContext instance here
                var dbContext = scope.ServiceProvider.GetService<ApplicationDataContext>();

                // place your DB seeding code here
                /*
                NEED TO ADD BACK IN SEEDING METHOD!
                https://www.ryadel.com/en/buildwebhost-unable-to-create-an-object-of-type-applicationdbcontext-error-idesigntimedbcontextfactory-ef-core-2-fix/
                 */
                // DbSeeder.Seed(dbContext);
            }
            host.Run();

            // ref.: https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
#if DEBUG || INTEGRATED
            .UseHttpSys(options => {
                options.Authentication.Schemes =
                    AuthenticationSchemes.NTLM | AuthenticationSchemes.Negotiate;
                options.Authentication.AllowAnonymous = false;
            })
#endif
            .UseStartup<Startup>()
            .Build();
    }
}
