using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CreditoCarteraAdmin_AbInBev.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Net;
using Microsoft.Extensions.Azure;
using Microsoft.AspNetCore.Authentication.Cookies;
using CreditoCarteraAdmin_AbInBev.IndetityStores;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CreditoCarteraAdmin_AbInBev
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));

            //services.AddMicrosoftIdentityWebAppAuthentication(Configuration, "AzureAd");


            services.AddIdentity<IdentityUser, IdentityRole>().AddUserStore<UserStore>().AddRoleStore<RoleStore>();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                auth.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddCookie(options => { options.LoginPath = "/Home/Index"; })
           .AddOpenIdConnect("AzureAD", "AzureAD", options =>
           {
               Configuration.GetSection("OpenIdConnect").Bind(options); ;
               options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
               options.RemoteAuthenticationTimeout = TimeSpan.FromSeconds(120);
               options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               options.RequireHttpsMetadata = false;
               options.SaveTokens = true;
           });

           services.AddDbContext<CartedaDBContext>(options => options.UseSqlServer(
                             "Server=tcp:abinbev.database.windows.net,1433;Initial Catalog=CartedaDB;Persist Security Info=False;User ID=adminuser;Password=Pass123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                         );


            //services.AddRazorPages().AddMvcOptions(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                  .RequireAuthenticatedUser()
            //                  .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //}).AddMicrosoftIdentityUI();

            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Home/login");

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
