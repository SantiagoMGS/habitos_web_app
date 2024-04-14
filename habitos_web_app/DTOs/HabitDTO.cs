using System.ComponentModel.DataAnnotations;

namespace habitos_app.Web.Models
{
    public class HabitDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int HabitTypeId { get; set; }
    }
}
