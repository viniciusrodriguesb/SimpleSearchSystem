using Application.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class FluentValidationConfiguration 
    {

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(FormularioRequestValidator));

            return services;
        }
    }
}
