namespace habitos_app.Web.Models;
using System.ComponentModel.DataAnnotations;



public class Habit
{
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    // Luego le ponemos frecuencia o algo as�, por ahora as�.
    // Otras propiedades comunes
}