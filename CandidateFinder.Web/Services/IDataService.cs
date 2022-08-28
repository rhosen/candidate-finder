using CandidateFinder.Web.Models;

namespace CandidateFinder.Web.Services
{
    public interface IDataService
    {
        Task<IList<Technology>> GetTechnologiesAsync();
        Task<IList<Candidate>> GetCandidatesAsync();
    }
}
