using System.ComponentModel.DataAnnotations;

namespace habitos_app.Web.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int UserTypeId { get; set; } 
    }
}
