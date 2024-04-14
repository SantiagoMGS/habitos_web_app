namespace habitos_app.Web.Models;
using System.ComponentModel.DataAnnotations;

public class UserType
{
    [Key] 
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

}
