using ApiSegundaPractica.Data;
using ApiSegundaPractica.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace ApiSegundaPractica;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        string conn = Configuration.GetConnectionString("SqlServer");
        services.AddTransient<RepositoryEventos>();
        services.AddDbContext<EventosContext>(options => options.UseSqlServer(conn));

        services.AddCors(options => options.AddPolicy("Allow", x => x.AllowAnyOrigin()));

        services.AddOpenApi();

        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(x => x.AllowAnyOrigin());

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapOpenApi();
            endpoints.MapScalarApiReference();
            endpoints.MapControllers();
            endpoints.MapGet("/", context =>
            {
                context.Response.Redirect("/scalar/v1");
                return Task.CompletedTask;
            });
        });
    }
}