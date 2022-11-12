using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadinhoNuvensFofas.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace MercadinhoNuvensFofas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly IWebHostEnvironment _appEnviroment;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext> // a variável options pode ter qualquer nome, pois ela virará a optionsDB
                (options => options.UseMySql("server=localhost;initial catalog=Mercadinho_Nuvens_Fofas;uid=root;pwd=griloseco347",
               Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"))
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Resolvendo o problema de ponto e vírgula no textbox do cadastrar

            // configurando a cultura e padronização de casas decimais

            // definindo a cultura padrão => português - Brasil
            var defaultCulture = "pt-BR";

            // definindo a formatação dos números
            var ci = new CultureInfo(defaultCulture);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            // preparar a camada de localização atual
            app.UseRequestLocalization
                (
                new RequestLocalizationOptions
                    {
                        DefaultRequestCulture = new RequestCulture (ci),
                        SupportedCultures = new List<CultureInfo>
                            {
                                ci // se der erro aqui, colocar vírgula nos dois ci's
                            },
                        SupportedUICultures = new List<CultureInfo>
                            {
                                ci
                            }
                    }
                );

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
