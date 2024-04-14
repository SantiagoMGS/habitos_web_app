namespace habitos_app.Web.Models;
using System.ComponentModel.DataAnnotations;

public class UserType
{
    [Key] // Indica que este campo es la clave primaria
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    // Lista de usuarios para establecer la relación uno a muchos
    // public List<User> Users { get; set; } = new List<User>();
}
