using ApplicationForm.Data;
using ApplicationForm.DTOs;
using ApplicationForm.Models;
using ApplicationForm.Repositories.Interfaces;
using ApplicationForm.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApplicationForm.Repositories.Implementations
{
    public class FormRepository : IFormRepository
    {
        private readonly FormDbContext _context;

        public FormRepository(FormDbContext context)
        {
            _context = context;
        }

        public async Task AddCandidateForm(CandidateApplyDto applyForm)
        {
            var candidateInfo = new CandidatePersonalInfo()
            {
                FirstName = applyForm.CandidateInfo.FirstName,
                LastName = applyForm.CandidateInfo.LastName,
                Email = applyForm.CandidateInfo.Email,
                PhoneNumber = applyForm.CandidateInfo.PhoneNumber,
                Nationality = applyForm.CandidateInfo.Nationality,
                CurrentResidence = applyForm.CandidateInfo.CurrentResidence,
                IDNumber = applyForm.CandidateInfo.IDNumber,
                DateOfBirth = applyForm.CandidateInfo.DateOfBirth,
                Gender = applyForm.CandidateInfo.Gender,
            };

            _context.Add(candidateInfo);
            _context.SaveChanges();

            foreach (var quest in applyForm.Questions)
            {
                var _candidateResponse = new CandidateQuestionResponse()
                {
                    QuestionType = quest.QuestionType,
                    Question = quest.Question,
                    Choice = quest.Choice,
                    MaxChoice = quest.MaxChoice,
                };
                _context.QuestionResponses.AddRange(_candidateResponse);
                _context.SaveChangesAsync();
            }
        }

        public async Task AddForm(ProgramDto programForm)
        {
            var postProg = new CreateProgram()
            {
                ProgramTitle = programForm.Program.ProgramTitle,
                ProgramDescription = programForm.Program.ProgramDescription,
            };

            _context.Add(postProg);
            _context.SaveChanges();

            var personalInfo = new PersonalInformation()
            {
                FirstName = programForm.PersonalInfo.FirstName,
                LastName = programForm.PersonalInfo.LastName,
                Email = programForm.PersonalInfo.Email,
                PhoneNumber = programForm.PersonalInfo.PhoneNumber,
                Nationality = programForm.PersonalInfo.Nationality,
                CurrentResidence = programForm.PersonalInfo.CurrentResidence,
                IDNumber = programForm.PersonalInfo.IDNumber,
                DateOfBirth =programForm.PersonalInfo.DateOfBirth,
                Gender = programForm.PersonalInfo.Gender,
            };

            _context.Add(personalInfo);
            _context.SaveChanges();

            foreach (var quest in programForm.Questions)
            {
                var _quest = new AdditionalQuestions()
                {
                    QuestionType = quest.QuestionType,
                    Question = quest.Question,
                    Choice = quest.Choice,
                    MaxChoice = quest.MaxChoice,
                };
                _context.Questions.AddRange(_quest);
                _context.SaveChangesAsync();
            }
        }

        public async Task<AdditionalQuestions> EditQuestion(AdditionalQuestionsDto questions)
        {
            var _question = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionType == questions.QuestionType);

            if (_question != null)
            {
                _question.QuestionType = questions.QuestionType;
                _question.Question = questions.Question;
                _question.Choice = questions.Choice;
                _question.MaxChoice = questions.MaxChoice;

                _context.SaveChangesAsync();
            }

            return _question;
        }

        public async Task<List<AdditionalQuestionsDto>> GetQuestionsByQuestionType(List<QuestionsEnum> questionType)
        {
            var question = new List<AdditionalQuestions>();

            var questionTypeDescriptions = questionType.Select(q => q.GetEnumDescription()).ToList();
            question = await _context.Questions
                .Where(x => questionTypeDescriptions.Contains(x.QuestionType))
                .ToListAsync();

            var questionsDto = question.Select(q => new AdditionalQuestionsDto
            {
                QuestionType = q.QuestionType,
                Question = q.Question,
                Choice = q.Choice,
                MaxChoice = q.MaxChoice,
            }).ToList();

            return questionsDto;            
        }
    }
}