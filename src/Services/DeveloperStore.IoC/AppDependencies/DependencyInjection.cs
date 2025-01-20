using DeveloperStore.Persistence.Context;
using DeveloperStore.Users.Application.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using MediatR;
using DeveloperStore.Users.Application.Behavior;
using DeveloperStore.Users.Domain.Interfaces;
using DeveloperStore.Persistence.Repositories;
using DeveloperStore.Users.Application.Commands.CreateUser;

namespace DeveloperStore.IoC.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UserDbContext>(options => {
                options.UseNpgsql(connection, builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                .CommandTimeout(10));
            });

           // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            var myHandlers = AppDomain.CurrentDomain.Load("DeveloperStore.Users.Application");
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(myHandlers);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);

            services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            services.AddScoped<IUserRepository, UserRepository>();

           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
