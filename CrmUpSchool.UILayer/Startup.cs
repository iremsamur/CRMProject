using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.BusinessLayer.Concrete;
using Crm.UpSchool.BusinessLayer.DIContainer;
using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.DataAccessLayer.EntityFramework;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer
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

            services.Containerdependencies();
            
            //Identity i�in a�a��dakileri ekleriz
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();//AddEntityFrameworkStores entity framework i�inde kullanmam�z� sa�lar
            services.AddControllersWithViews();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()//bu k�s�m t�m sayfalarda yetkilendirme yani kullan�c� login olmadan hi�bir sayfaya eri�ememesini sa�lar
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));


            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";//kullan�c� login olmadan eri�meye �al���rsa login sayfas�na y�nlendirilmesini sa�lar
            });
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
            app.UseAuthentication();//login i�lemi i�in bunu ekliyoruz

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //areas kullan�m� i�in bunu ekliyoruz
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                
            });

        }
    }
}
