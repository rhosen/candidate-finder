using CandidateFinder.Web.Models;
using CandidateFinder.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateFinder.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IDataService _dataService;
        private readonly ICandidateService _candidateService;

        public CandidateController(
            IDataService dataService,
            ICandidateService candidateService
            )
        {
            _dataService = dataService;
            _candidateService = candidateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetTechnologies()
        {
            var technlogies = await _dataService.GetTechnologiesAsync();
            return Json(technlogies);
        }


        [HttpPost]
        public async Task<IActionResult> FindMatch([FromBody] IEnumerable<Experience> criterias)
        {
            var result = await _candidateService.FindMatchAsync(criterias);
            return Json(result);
        }
    }
}
