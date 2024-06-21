namespace ApplicationForm.DTOs
{
    public class CandidateQuestionsResponeDto
    {
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public string? Choice { get; set; }
        public int? MaxChoice { get; set; }
    }
}
