using Application.Services;
using Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextBase>(options => options.UseNpgsql(configuration.GetConnectionString("SupabaseConnection")));

            ConfigurarClientHttp(services);
            ConfigurarServicos(services);

            return services;
        }

        private static void ConfigurarClientHttp(IServiceCollection services)
        {
            services.AddHttpClient();
        }
        private static void ConfigurarServicos(IServiceCollection services)
        {
            services.AddScoped<FormularioService>();
            services.AddScoped<PaginacaoService>();
        }
    }
}
