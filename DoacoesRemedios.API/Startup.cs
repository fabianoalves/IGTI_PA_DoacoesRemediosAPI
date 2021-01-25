using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using DoacoesRemedios.Data;
using DoacoesRemedios.Domain;

namespace DoacoesRemedios.API
{
    class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GNLiteDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("GNLiteDbContext"));
            });
            services.AddTransient<IRepository<Instituicao>, RepositorioBaseEF<Instituicao>>();
            services.AddTransient<IRepository<Usuario>, RepositorioBaseEF<Usuario>>();

            services.AddCors();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
