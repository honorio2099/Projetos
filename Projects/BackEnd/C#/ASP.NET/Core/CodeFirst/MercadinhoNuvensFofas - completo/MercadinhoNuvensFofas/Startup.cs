using MercadinhoNuvensFofas.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MercadinhoNuvensFofas
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
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>
                (options => options.UseMySql(
                    "server=localhost;initial catalog=MERCADINHO_NOITE;uid=root;pwd=alunos",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"))
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /////////////////////////////////////////////////////////////////////////////////
            // CONFIGURANDO A CULTURA E PADRONIZAÇÃO DE CASAS DECIMAIS

            // definindo a cultura padrão => portugues BRASIL
            var defaultCulture = "pt-BR";

            // definir a formatação dos números
            var ci = new CultureInfo(defaultCulture);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            // preparar a camada de localização atual
            app.UseRequestLocalization
                (
                new RequestLocalizationOptions 
                    {
                        DefaultRequestCulture = new RequestCulture(ci),
                        SupportedCultures = new List<CultureInfo> 
                            {
                                ci
                            },
                        SupportedUICultures = new List<CultureInfo> 
                            {
                                ci
                            }
                    }
                );
            //////////////////////////////////////////////////////////////////////////////////

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
