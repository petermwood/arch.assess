using AG.Common.Helpers;
using AG.Data.Contracts;
using AG.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AG.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.RegisterServices();

            var serviceProvider = services.BuildServiceProvider();

            var tweetManager = serviceProvider.GetService<ITweetManager>();

            if(await tweetManager.Run())
            {
                DisplayGeneralOutput.PrintMessageFooter();
            }
        }
    }
}
