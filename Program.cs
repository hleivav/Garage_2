﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage_2.Data;
namespace Garage_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Garage_2Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Garage_2Context") ?? throw new InvalidOperationException("Connection string 'Garage_2Context' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            TEEST
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Vehicles}/{action=Index}/{id?}");

            app.Run();
        }
    }
}