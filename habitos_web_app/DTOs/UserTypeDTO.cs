using System.ComponentModel.DataAnnotations;

namespace habitos_app.Web.Models
{
    public class UserTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
