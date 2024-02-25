using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PT.Application.Features.Roles.Commands.RoleInsert;

namespace PT.Application.DependencyInjection
{
    public static class ValidatorsInjection
    {
        public static IServiceCollection AddValidatorsServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RoleInsertCommand>, RoleInsertCommandValidator>();

            return services;
        }
    }
}
