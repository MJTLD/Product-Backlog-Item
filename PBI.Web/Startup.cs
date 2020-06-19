using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PBI.Data.EF.Context;
using PBI.Repository.IRepository;
using PBI.Repository.Repository;
using PBI.Service.IService;
using PBI.Service.Service;

namespace PBI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "AllowMyOrigin";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builders =>
                {
                    builders.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.Configure<CookiePolicyOptions>(options =>
           {
               // This lambda determines whether user consent for non-essential cookies is needed for a given request.
               options.CheckConsentNeeded = context => true;
               options.MinimumSameSitePolicy = SameSiteMode.None;
           });

            //Injection
            services.AddScoped<IPBIRepository, PBIRepository>();
            services.AddScoped<ILetterService, LetterService>();

            //context
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<PBIContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"],
                    sqlOptions =>
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            },
                ServiceLifetime.Singleton
            );

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();

            services.AddMvc(options =>
                {
                    options.CacheProfiles.Add("DefaultNoCacheProfile", new CacheProfile
                    {
                        NoStore = true,
                        Location = ResponseCacheLocation.None
                    });
                    options.Filters.Add(new ResponseCacheAttribute
                    {
                        CacheProfileName = "DefaultNoCacheProfile"
                    });
                }).SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddDistributedMemoryCache();

            //services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
            });
            services.AddHttpClient();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

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
