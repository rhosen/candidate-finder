namespace CandidateFinder.Web.Models
{
    public class Candidate
    {
        public string CandidateId { get; set; }
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public List<Experience> Experience { get; set; }
    }
}
