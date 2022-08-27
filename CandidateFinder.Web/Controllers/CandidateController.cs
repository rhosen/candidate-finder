using CandidateFinder.Web.Models;
using CandidateFinder.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateFinder.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IDataService _dataService;

        public CandidateController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnologies()
        {
            var technlogies = await _dataService.GetTechnologies();
            return Json(technlogies);
        }


        [HttpPost]
        public async Task<IActionResult> FindMatch([FromBody] List<Experience> criterias)
        {
            var filtered = new List<Candidate>();
            var candidates = await _dataService.GetCandidates();
            var count = criterias.Count();
            foreach (var candidate in candidates)
            {
                var sum = 0;
                foreach (var criteria in criterias)
                {
                    var hasSkill = candidate.Experience.Any(x => x.TechnologyId == criteria.TechnologyId &&
                                                            x.YearsOfExperience >= criteria.YearsOfExperience);
                    if (hasSkill) sum++;
                }
                if (sum == count) filtered.Add(candidate);
            }
            return Json(filtered);
        }
    }
}
