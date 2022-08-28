using CandidateFinder.Web.Models;

namespace CandidateFinder.Web.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IDataService _dataService;

        public CandidateService(IDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<IList<Candidate>> FindMatchAsync(IEnumerable<Experience> criterias)
        {
            var filtered = new List<Candidate>();
            var candidates = await _dataService.GetCandidatesAsync();
            var count = criterias.Count();
            foreach (var candidate in candidates)
            {
                var matched = 0;
                foreach (var criteria in criterias)
                {
                    var hasSkill = candidate.Experience.Any(x => x.TechnologyId == criteria.TechnologyId &&
                                                            x.YearsOfExperience >= criteria.YearsOfExperience);
                    if (hasSkill) matched++;
                }
                if (matched == count) filtered.Add(candidate);
            }
            return filtered;
        }
    }
}
