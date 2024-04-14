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


    public int UserTypeId { get; set; }


    [ForeignKey("UserTypeId")]
    public UserType? UserType { get; set; }

}
