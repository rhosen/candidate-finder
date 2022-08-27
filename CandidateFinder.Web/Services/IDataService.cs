using CandidateFinder.Web.Models;

namespace CandidateFinder.Web.Services
{
    public interface IDataService
    {
        Task<IList<Technology>> GetTechnologies();
        Task<IList<Candidate>> GetCandidates();
    }
}
