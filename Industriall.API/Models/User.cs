using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Industriall.API.Models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }
    
    public string? LastName { get; set; }
    
    public string identityUserId{ get; set; }

    public void UpdateUser(User newUser)
    {
        Name = newUser.Name ?? Name;
        LastName = newUser.LastName ?? LastName;
    }
}