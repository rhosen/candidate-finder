using CandidateFinder.Web.Models;

namespace CandidateFinder.Web.Services
{
    public interface ICandidateService
    {
        Task<IList<Candidate>> FindMatch(List<Experience> criterias);
    }
}
