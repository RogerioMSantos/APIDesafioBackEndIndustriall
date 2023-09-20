using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Industriall.Application.Model;

namespace Industriall.API.Models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ApplicationUser? IdentityUser { get; set; }

    public void UpdateUser(User newUser)
    {
        Name = newUser.Name ?? Name;
        LastName = newUser.LastName ?? LastName;
    }
}