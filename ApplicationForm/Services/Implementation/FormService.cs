using ApplicationForm.DTOs;
using ApplicationForm.Models;
using ApplicationForm.Repositories.Interfaces;
using ApplicationForm.Services.Interface;
using Microsoft.Extensions.Logging;

namespace ApplicationForm.Services.Implementation
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _repository;
        private readonly ILogger<FormService> _logger;
        public FormService(IFormRepository repository, ILogger<FormService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void AddCandidateForm(CandidateApplyDto applyForm)
        {
            try
            {
                _repository.AddCandidateForm(applyForm);
            }

            catch (Exception e)
            {
                _logger.LogError($"ERROR:: {e.Message} \n\n - StackTrace:: {e.StackTrace}");
                throw;
            }
        }

        public void AddForm(ProgramDto programForm)
        {
            try
            {
                _repository.AddForm(programForm);
            }

            catch (Exception e)
            {
                _logger.LogError($"ERROR:: {e.Message} \n\n - StackTrace:: {e.StackTrace}");
                throw;
            }
        }

        public async Task<List<AdditionalQuestionsDto>> GetQuestionsByQuestionType(List<QuestionsEnum> questionsEnum)
        {
            try
            {
                return await _repository.GetQuestionsByQuestionType(questionsEnum);
            }

            catch (Exception e)
            {
                _logger.LogError($"ERROR:: {e.Message} \n\n - StackTrace:: {e.StackTrace}");
                throw;
            }
        }

        public async Task<AdditionalQuestions> EditQuestion(AdditionalQuestionsDto questions)
        {
            try
            {
                return await _repository.EditQuestion(questions);
            }

            catch (Exception e)
            {
                _logger.LogError($"ERROR:: {e.Message} \n\n - StackTrace:: {e.StackTrace}");
                throw;
            }
        }
    }
}
