namespace habitos_app.Web.Models;

using habitos_web_app.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Habit
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public int HabitTypeId { get; set; }

    [ForeignKey("HabitTypeId")]
    public HabitType HabitType { get; set; }

    // Luego le ponemos frecuencia o algo así, por ahora así.
    // Otras propiedades comunes
}