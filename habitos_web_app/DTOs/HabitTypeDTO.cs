using System.ComponentModel.DataAnnotations;

namespace habitos_app.Web.Models
{
    public class HabitTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
