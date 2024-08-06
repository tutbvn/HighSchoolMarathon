namespace HighSchoolMarathon.WebApp.Models
{
    public class RankingModel
    {
        public int Ranking { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BibNumber { get; set; } = string.Empty;
        public string  ClassName { get; set; } = string.Empty;
        public int Age { get; set; } = 10;
        public string Gender { get; set; } = "Male";
    }
}
