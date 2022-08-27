using CandidateFinder.Web.Services;

namespace CandidateFinder.Web.DI
{
    public static class CandidateServiceExtension
    {
        public static IServiceCollection AddCandidateService(this IServiceCollection services)
        {
            services.AddHttpClient<IDataService, DataService>();
            services.AddScoped<ICandidateService, CandidateService>();
            return services;
        }
    }
}
