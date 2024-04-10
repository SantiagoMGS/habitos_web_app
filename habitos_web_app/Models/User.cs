namespace habitos_app.Web.Models;
using System.ComponentModel.DataAnnotations;



public class User
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress] // Valida también el formato de correo electrónico
    public string Email { get; set; }

    // Otras propiedades comunes
}