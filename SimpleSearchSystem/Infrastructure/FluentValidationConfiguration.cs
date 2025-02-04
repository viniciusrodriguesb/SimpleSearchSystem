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
            services.AddValidatorsFromAssemblyContaining(typeof(EditFormularioValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(PerguntaRequestValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(EditPerguntaRequestValidator));

            return services;
        }
    }
}
