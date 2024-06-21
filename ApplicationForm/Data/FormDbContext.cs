using ApplicationForm.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForm.Data
{
    public class FormDbContext : DbContext
    {
        public FormDbContext( DbContextOptions<FormDbContext> options) : base(options)
        {
                
        }

        public DbSet<CreateProgram> Programs { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<AdditionalQuestions> Questions { get; set; }
        public DbSet<CandidateQuestionResponse> QuestionResponses { get; set; }
        public DbSet<CandidatePersonalInfo> CandidatePersonalInfos { get; set; }

    }
}
