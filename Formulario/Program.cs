using Formulario.Application.Data;
using Formulario.Application.Services;
using Formulario.Domain.Interfaces;
using Formulario.Infraestructure.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Formulario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            //INYECCIÓN DEPENDENCIA

            //builder.Services.AddScoped<IContactRepo, ContactRepo>(); //Cambia para diferentes requests
            builder.Services.AddSingleton<IContactRepo, ContactRepo>(); //Se mantiene para diferentes requests. Lifetime->No se limpia con el garbage collector

            builder.Services.AddScoped<ContactService>(); //SINGLETON PETA EN ESTE SERVICIO AL DUPLICAR LA WEB! Hilo secundario !=> Dispatcher


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();


            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host"); //DUDA CUANDO CAMBIO LAS RUTAS!

            app.Run();
        }
    }
}