namespace ApplicationForm.DTOs
{
    public class ProgramDto
    {
        public CreateProgramDto Program { get; set; }
        public PersonalInformationDto PersonalInfo { get; set; }
        public List<AdditionalQuestionsDto> Questions { get; set; }
    }
}
