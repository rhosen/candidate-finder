using CandidateFinder.Web.Models;
using CandidateFinder.Web.Utility;
using CandidateFinder.Web.Services;

namespace CandidateFinder.Web.DI
{
    public static class IFSService
    {
        public static IServiceCollection AddIFSService(this IServiceCollection services)
        {
            services.AddHttpClient<IDataService, DataService>();
            return services;
        }
    }
}
