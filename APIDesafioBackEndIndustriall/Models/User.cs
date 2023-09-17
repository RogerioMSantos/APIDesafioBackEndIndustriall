using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace APIDesafioBackEndIndustriall.Models;

public class User
{
    [Required]
    public string Name { get; set; }
    
    private string _password; 
    [Required][RegularExpression("^(?=.*\\d).{6,}$")]
    public string Password
    {
        get => _password;
        set
        {
            string pattern = @"^(?=.*\d).{6,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, pattern))
            {

                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres e conter pelo menos um número.");
            }
            this._password = value;

        }
    }

    public User()
    {

    }
    
}