using CandidateFinder.Web.Models;

namespace CandidateFinder.Web.Services
{
    public class DataService : ServiceBase, IDataService
    {
        private readonly ILogger<DataService> _logger;

        public DataService(
            HttpClient httpClient,
            ILogger<DataService> logger
            ) :base(httpClient)
        {
            _logger = logger;
        }
       
        public async Task<IList<Technology>> GetTechnologiesAsync()
        {
            var technologies = new List<Technology>();
            try
            {
                technologies = await GetAsync<List<Technology>>(Utility.Endpoint.GetTechnologies);
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get technologies.", ex.GetBaseException().Message);
            }
            return technologies;
        }

        public async Task<IList<Candidate>> GetCandidatesAsync()
        {
            var candidates = new List<Candidate>();
            try
            {
                candidates = await GetAsync<List<Candidate>>(Utility.Endpoint.GetCandidates);
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get candidates.", ex.GetBaseException().Message);
            }
            return candidates;
        }
    }
}
