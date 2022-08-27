using CandidateFinder.Web.Models;
using CandidateFinder.Web.Utility;

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
       
        public async Task<IList<Technology>> GetTechnologies()
        {
            var technologies = new List<Technology>();
            try
            {
                technologies = await GetAsync<List<Technology>>(IFSConstant.GetTechnologies);
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get technologies.", ex.GetBaseException().Message);
            }
            return technologies;
        }

        public async Task<IList<Candidate>> GetCandidates()
        {
            var candidates = new List<Candidate>();
            try
            {
                candidates = await GetAsync<List<Candidate>>(IFSConstant.GetCandidates);
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get candidates.", ex.GetBaseException().Message);
            }
            return candidates;
        }
    }
}
