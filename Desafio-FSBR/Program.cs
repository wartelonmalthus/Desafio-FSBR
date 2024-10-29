using Desafio_FSBR.Data.Context;
using Desafio_FSBR.Data.Interfaces;
using Desafio_FSBR.Data.Repositories;
using Desafio_FSBR.Service.ExternalApi;
using Desafio_FSBR.Service.Interfaces;
using Desafio_FSBR.Service.Services;
using Microsoft.EntityFrameworkCore;
using Refit;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //repository
        builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();

        //service
        builder.Services.AddScoped<IProcessoService, ProcessoService>();


        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //refit
        var ibgeApiBaseUrl = builder.Configuration.GetSection("ApiExterna:IbgeApiUrl").Value;
        builder.Services.AddRefitClient<IIbgeApiService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(ibgeApiBaseUrl));

        var brasilApiBaseUrl = builder.Configuration.GetSection("ApiExterna:BrasilApiUrl").Value;
        builder.Services.AddRefitClient<IBrasilApiService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(brasilApiBaseUrl));


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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}