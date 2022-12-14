using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Shop1.Data.interfaces;


using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shop1.Data;
using Shop1.Data.Models;
using Shop1.Data.Repository;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;


namespace Shop1;

public class Startup
{



    private IConfigurationRoot _confstring;

    public Startup(IWebHostEnvironment hostEnv)
    {
        _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
    }


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContent>(options =>
            options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
        services.AddTransient<IAllCars, CarRepository>();
        services.AddTransient<ICarsCategory, CategoryRepository>();
        services.AddTransient<IAllOrders, OrdersRepository>();
        services.AddControllersWithViews();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped(ShopCart.GetCart);
        services.AddMvc();
        services.AddMemoryCache();
        services.AddSession();
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

        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseSession();

        using (var scope = app.ApplicationServices.CreateScope())
        {
            AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
            DbObjects.Initial(content);
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
        });
    }
}


