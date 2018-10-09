using ExpenseTracker.Common;
using ExpenseTracker.Core;
using ExpenseTracker.Core.Contract;
using ExpenseTracker.Repository;
using ExpenseTracker.Repository.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace ExpenseTracker.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connection = @"Server=(localdb)\mssqllocaldb;Database=ExpenseTracker;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<ExpenseTrackerContext>
                (options => options.UseSqlServer(connection));
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IStaticDataProvider, StaticDataProvider>();
            services.AddSingleton<ILogFactory, LogFactory>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseExceptionHandler(
                 options =>
                 {
                     options.Run(
                     async context =>
                     {
                         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                         context.Response.ContentType = "text/html";
                         var ex = context.Features.Get<IExceptionHandlerFeature>();
                         if (ex != null)
                         {
                             var err = env.IsDevelopment()
                                ? $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }"
                                : $"<h1>Error</h1>Please contact support.";

                             await context.Response.WriteAsync(err).ConfigureAwait(false);
                         }

                         var logger = new LogFactory().GetLogger<Startup>();
                         logger.Error("An error has occured.", ex?.Error);
                     });
                 });
        }
    }
}
