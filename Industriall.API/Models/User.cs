using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Industriall.API.Models;

public class User
{
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string? Name { get; set; } = null!;
    
    [RegularExpression("^(?=.*\\d).{6,}$", ErrorMessage = "A senha deve conter pelo menos 6 caracteres e 1 número")]
    [DataType(DataType.Password)]
    public string? Password { get; set; } = null!;

    public override string ToString()
    {
        return $"Name: {Name}";
    }

    public void UpdateUser(User newUser)
    {
        Name = newUser.Name ?? Name;
        Password = newUser.Password ?? Password;
        
    }
}