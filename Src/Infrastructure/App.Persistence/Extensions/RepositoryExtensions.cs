using App.Application.Contracts.Persistence;
using App.Domain.Options;
using App.Persistence.Cities;
using App.Persistence.FootballFields;
using App.Persistence.Reservations;
using App.Persistence.Towns;
using App.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace App.Persistence.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionStrings = configuration.GetRequiredSection(ConnectionStringOption.Key)
                .Get<ConnectionStringOption>();

                options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
                });

                //options.AddInterceptors(new AuditDbContextInterceptor());
            });

            services.AddScoped<IFootballFieldRepository,FootballFieldRepository>();
            services.AddScoped<IReservationRepository,ReservationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICityRepository,CityRepository>();
            services.AddScoped<ITownRepository,TownRepository>();

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
