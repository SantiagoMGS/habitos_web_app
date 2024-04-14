using System.ComponentModel.DataAnnotations;

namespace habitos_app.Web.Models
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int UserTypeId { get; set; } 
    }
}
