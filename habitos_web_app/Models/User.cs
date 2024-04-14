namespace habitos_app.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    // Clave for�nea de UserType
    public int UserTypeId { get; set; }

    // Propiedad de navegaci�n para UserType
    [ForeignKey("UserTypeId")]
    public UserType? UserType { get; set; }

}
