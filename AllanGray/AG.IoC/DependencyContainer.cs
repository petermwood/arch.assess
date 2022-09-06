using AG.Data.Contracts;
using AG.Data.Services;
using AG.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace AG.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<ITweetBuilder, TweetBuilder>();
            services.AddScoped<IUserBuilder, UserBuilder>();
            services.AddScoped<ITweetManager, TweetManager>();
         
            return services;
        }
    }
}
