using ApplicationForm.DTOs;
using ApplicationForm.Models;

namespace ApplicationForm.Repositories.Interfaces
{
    public interface IFormRepository
    {
        public Task AddForm(ProgramDto programForm);
        public Task<AdditionalQuestions> EditQuestion(AdditionalQuestionsDto questions);
        public Task<List<AdditionalQuestionsDto>> GetQuestionsByQuestionType(List<QuestionsEnum> questionType);
        public Task AddCandidateForm(CandidateApplyDto applyForm);
    }
}
