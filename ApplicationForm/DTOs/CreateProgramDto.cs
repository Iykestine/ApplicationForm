using ApplicationForm.Models;
using System.ComponentModel.DataAnnotations;

namespace ApplicationForm.DTOs
{
    public class CreateProgramDto
    {
        [Required]
        public string ProgramTitle { get; set; }
        [Required]
        public string ProgramDescription { get; set; }
    }
}
