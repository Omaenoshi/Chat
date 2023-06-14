using System.ComponentModel.DataAnnotations;

namespace Chat.Api.ViewModels;

public class RegisterModel
{
    [Required] public string Name { get; set; }

    [Required] public string Login { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}