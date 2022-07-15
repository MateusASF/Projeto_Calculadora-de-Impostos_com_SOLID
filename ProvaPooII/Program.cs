using Microsoft.Extensions.DependencyInjection;
using ProvaPooII.ProgramFlow;
using ProvaPOOII.Services;
using ProvaPOOII.Services.Interfaces;

namespace ProvaPOOII
{
    public class Program
    {
        public static void Main()
        {
            ServiceCollection services = new();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var mainFlow = serviceProvider.GetService<IProgramFlow>();

            mainFlow.Navigate();

        }

        //Container
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProgramFlow, ProgramFlow>();
            services.AddScoped<ITaxCalculator, TaxCalculator>();
        }
    }

}