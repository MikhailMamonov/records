

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Records.Appllication.Interfaces;

namespace Records.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration) {
            services.AddDbContext<RecordsDbContext>(options =>
            {
                options.UseInMemoryDatabase("Records");
            });
            services.AddScoped<IRecordsDbContext>(provider =>
                provider.GetService<RecordsDbContext>());

            return services;
        }
    }
}
