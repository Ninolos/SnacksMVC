﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SnackMVC.Context;
using SnackMVC.Models;
using SnackMVC.Repositories;
using SnackMVC.Repositories.Interfaces;
using SnackMVC.Services;

namespace SnackMVC;

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
        services.AddControllersWithViews();
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        services.AddTransient<ISnackRepository, SnackRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin",
                politic =>
                {
                    politic.RequireRole("Admin");
                });
        });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddScoped(sp => ShopCart.GetCart(sp));
        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
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
        seedUserRoleInitial.SeedRoles();
        seedUserRoleInitial.SeedUsers();

        app.UseSession();

        //create profile
        app.UseAuthentication();
        //create users and attibute to the profile
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            
            endpoints.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                );          

            endpoints.MapControllerRoute(
               name: "categoryFilter",
               pattern: "Snack/{action}/{category?}",
               defaults: new { Controller = "Snack", action = "List" });

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
        });
    }
}