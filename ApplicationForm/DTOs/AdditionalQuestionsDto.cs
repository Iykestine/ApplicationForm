using ApplicationForm.Models;

namespace ApplicationForm.DTOs
{
    public class AdditionalQuestionsDto
    {
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public string? Choice { get; set; }
        public int? MaxChoice { get; set; }     
        public QuestionsEnum QuestionTypes { get; set; }
    }
}
