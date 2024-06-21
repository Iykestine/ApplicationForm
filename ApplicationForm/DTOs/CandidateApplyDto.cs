namespace ApplicationForm.DTOs
{
    public class CandidateApplyDto
    {
        public CandidatePersonalInfoDto CandidateInfo { get; set; }
        public List<CandidateQuestionsResponeDto> Questions { get; set; }
    }
}
