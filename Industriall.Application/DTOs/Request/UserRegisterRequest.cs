using System.ComponentModel.DataAnnotations;

namespace Industriall.Application.DTOs.Request;

public class UserRegisterRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [RegularExpression("^(?=.*\\d).{6,}$", ErrorMessage = "A senha deve conter pelo menos 6 caracteres e 1 número")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais")]
    public string PasswordConfimation { get; set; }
}