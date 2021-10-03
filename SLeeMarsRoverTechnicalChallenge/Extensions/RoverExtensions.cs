using Microsoft.Extensions.DependencyInjection;
using SLeeMarsRoverTechnicalChallenge.Interfaces;
using SLeeMarsRoverTechnicalChallenge.Repositories;

namespace SLeeMarsRoverTechnicalChallenge.Extensions
{
    public static class RoverExtensions
    {
        public static IServiceCollection AddRoverDependencies(this IServiceCollection services)
        {
            return services
                 .AddSingleton<IReportService, ReportService>();
        }
    }
}