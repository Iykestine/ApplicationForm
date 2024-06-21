using System.ComponentModel.DataAnnotations;

namespace ApplicationForm.Models
{
    public class CreateProgram
    {
        [Key]
        public int ProgramId { get; set; }
        [Required]
        public string ProgramTitle { get; set; }
        [Required]
        public string ProgramDescription { get; set; }
    }
}
