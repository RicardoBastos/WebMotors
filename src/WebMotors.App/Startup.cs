using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WebMotors.App.AnuncioMS.Domain.Interfaces.Repositories;
using WebMotors.App.AnuncioMS.Domain.Interfaces.Services;
using WebMotors.App.AnuncioMS.Domain.Services;
using WebMotors.App.AnuncioMS.Infra;
using WebMotors.App.AnuncioMS.Infra.Repositories;
using AnuncioEntity = WebMotors.App.AnuncioMS.Domain.Entities.Anuncio;

namespace WebMotors.App
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
            //services.AddDbContext<AnuncioContext>(opt => opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddDbContext<AnuncioContext>(opt => opt.UseInMemoryDatabase("teste"));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Micro serviço - Anúncio",
                    Description = "Teste para webmotors - backend",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Riardo Bastos",
                        Email = "ricardo3bastos@gmail.com",
                        Url = new Uri("https://github.com/RicardoBastos"),
                    },
                });
            });

            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<IAnuncioService, AnuncioService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AnuncioContext context)
        {
            AddAnuncios(context);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Webmotors");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddAnuncios(AnuncioContext context)
        {
            var anuncioUm = new AnuncioEntity();
            anuncioUm.SetAnuncio("Audi", "LX", "1.3", 2010, 40000, "único dono");

            var anuncioDois = new AnuncioEntity();
            anuncioDois.SetAnuncio("Chevrolet", "LT", "1.9", 2012, 20000, "único dono");

            context.Anuncio.Add(anuncioUm);
            context.Anuncio.Add(anuncioDois);


            context.SaveChanges();
        }
    }
}
