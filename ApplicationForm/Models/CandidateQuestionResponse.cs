namespace ApplicationForm.Models
{
    public class CandidateQuestionResponse
    {
        public int Id { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public string? Choice { get; set; }
        public int? MaxChoice { get; set; }
    }
}
