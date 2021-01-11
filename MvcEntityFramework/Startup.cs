using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            services.AddSingleton<IDepartamentosContext>(context => new DepartamentosContextSQL(cadena));
            //LAS DEPENDENCIAS DE OBJETOS SE RESUELVEN EN LOS SERVICIOS DE LA APP, LA PRIMERA OPCION SERIA UTILIZAR
            //ADDTRANSIENT QUE GENERA UN OBJETO POR CADA PETICION DE INYECCION
            //services.AddTransient<Coche>();
            //TAMBIEN TENEMOS LA OPCION DE CREAR UNA UNICA INSTANCIA DE UN OBJETO PARA TODAS LAS PETICIONES DE INYECCION
            //services.AddSingleton<Coche>();
            //services.AddSingleton<ICoche, Deportivo>();
            services.AddSingleton<ICoche>(z => new Deportivo("Ferrari", "Testarrossa", "ferrari.jpg", 290));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
