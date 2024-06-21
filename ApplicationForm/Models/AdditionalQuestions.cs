using System.ComponentModel;

namespace ApplicationForm.Models
{
    public class AdditionalQuestions
    {
        public int Id { get; set; }
        public string QuestionType { get; set; }        
        public string Question { get; set; }
        public string? Choice { get; set; }
        public int? MaxChoice { get; set; }
    }

    public class AddQuestionList
    {
        public List<AdditionalQuestions>? Quest { get; set; } = new List<AdditionalQuestions>();
    }


    public enum QuestionsEnum
    {
        [Description("Paragraph")] Paragraph = 0,
        [Description("Yes/No")] YesNo,
        [Description("Dropdown")] DropDown,
        [Description("MultipleChoice")] MultipleChoice,
        [Description("Date")] Date,
        [Description("Number")] Number,
    }
}
