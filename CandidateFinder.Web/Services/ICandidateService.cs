using CandidateFinder.Web.Models;

namespace CandidateFinder.Web.Services
{
    public interface ICandidateService
    {
        Task<IList<Candidate>> FindMatch(IEnumerable<Experience> criterias);
    }
}
