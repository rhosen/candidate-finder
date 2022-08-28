using CandidateFinder.Web.Models;

namespace CandidateFinder.Web.Services
{
    public interface ICandidateService
    {
        Task<IList<Candidate>> FindMatchAsync(IEnumerable<Experience> criterias);
    }
}
