using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}