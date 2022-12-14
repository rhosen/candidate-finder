using Moq;
using Xunit;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using CandidateFinder.Web.Models;
using CandidateFinder.Web.Services;


namespace CandidateFinder.Test
{
    public class CandidateServiceTest
    {
        private readonly Mock<IDataService> _dataService;
        private readonly CandidateService _candidateService;
        private static string RustId = "3B85BE83-9B4E-4B15-9EB2-68363936CA04";
        private static string PythonId = "3B85BE83-9B4E-4B15-9EB2-68363936CA06";
        private static string TypeScriptId = "3B85BE83-9B4E-4B15-9EB2-68363936CA05";
        private static string JavaScriptId = "3B85BE83-9B4E-4B15-9EB2-68363936CA13";
        private static string KotlinId = "3B85BE83-9B4E-4B15-9EB2-68363936CA07";
        private static string CSharpId = "3B85BE83-9B4E-4B15-9EB2-68363936CA11";

        public CandidateServiceTest()
        {
            _dataService = new Mock<IDataService>();
            ArrangeData();
            _candidateService = new CandidateService(_dataService.Object);
        }

        [Fact]
        public async Task ShouldReturn4_For5YearsRustExperience()
        {
            var criterias = new List<Experience>()
            {
                new Experience(){TechnologyId = RustId, YearsOfExperience = 5}
            };
            var filtered = await _candidateService.FindMatchAsync(criterias);
            Assert.Equal(4, filtered.Count);
        }

        [Fact]
        public async Task ShouldReturn8_For8YearsPythonExperience()
        {
            var criterias = new List<Experience>()
            {
                new Experience(){TechnologyId = PythonId, YearsOfExperience = 8}
            };
            var filtered = await _candidateService.FindMatchAsync(criterias);
            Assert.Equal(8, filtered.Count);
        }

        [Fact]
        public async Task ShouldReturn0_For10YearsRustAnd8YearsPythonExperience()
        {
            var criterias = new List<Experience>()
            {
                new Experience(){TechnologyId = RustId, YearsOfExperience = 10},
                new Experience(){TechnologyId = PythonId, YearsOfExperience = 8}
            };
            var filtered = await _candidateService.FindMatchAsync(criterias);
            Assert.Equal(0, filtered.Count);
        }

        [Fact]
        public async Task ShouldReturn1_For5YearsTypeScriptJavascriptKotlinExperience()
        {
            var criterias = new List<Experience>()
            {
                new Experience(){TechnologyId = TypeScriptId, YearsOfExperience = 5},
                new Experience(){TechnologyId = JavaScriptId, YearsOfExperience = 5},
                new Experience(){TechnologyId = KotlinId, YearsOfExperience = 5}
            };
            var filtered = await _candidateService.FindMatchAsync(criterias);
            Assert.Equal(1, filtered.Count);
        }

        [Fact]
        public async Task ShouldReturn10_For4YearsCSharpExperience()
        {
            var criterias = new List<Experience>()
            {
                new Experience(){TechnologyId = CSharpId, YearsOfExperience = 4},
            };
            var filtered = await _candidateService.FindMatchAsync(criterias);
            Assert.Equal(10, filtered.Count);
        }

        private void ArrangeData()
        {
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"TestData\Candidates.json");
            var data = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var candidates = JsonSerializer.Deserialize<IList<Candidate>>(data, options);
            _dataService.Setup(x => x.GetCandidatesAsync()).Returns(Task.FromResult(candidates));
        }
    }
}