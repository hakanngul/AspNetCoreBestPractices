using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web
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
            services.AddHttpClient<CategoryApiService>(options =>
            {
                options.BaseAddress = new Uri(Configuration["baseUrl"]);
            });

            services.AddHttpClient<ProductApiService>(options =>
            {
                options.BaseAddress = new Uri(Configuration["baseUrl"]);
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddControllersWithViews();
            // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            // services.AddScoped<ICategoryService, CategoryService>();
            // services.AddScoped<IProductService, ProductService>();
            //
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddDbContext<AppDbContext>(options =>
            // {
            //     options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"], o =>
            //     {
            //         o.MigrationsAssembly("UdemyNLayerProject.Data");
            //     });
            // });
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