using ApplicationForm.DTOs;
using ApplicationForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.Services.Interface
{
    public interface IFormService
    {
        public void AddForm(ProgramDto programForm);
        public Task<AdditionalQuestions> EditQuestion(AdditionalQuestionsDto questions);
        public void AddCandidateForm(CandidateApplyDto applyForm);
        public Task<List<AdditionalQuestionsDto>> GetQuestionsByQuestionType(List<QuestionsEnum> questionsEnum);
    }
}
