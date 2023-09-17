using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace APIDesafioBackEndIndustriall.Models;

public class User
{
    [Required]
    public string Name { get; set; }
    

    [Required]
    [RegularExpression("^(?=.*\\d).{6,}$",ErrorMessage = "A senha deve conter pelo menos 6 caracteres e 1 número")][DataType (DataType.Password)]
    public string Password { get; set; }
    

    public User()
    {

    }

    public override string ToString()
    {
        return $"Name: {Name}";
    }
}