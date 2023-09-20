using System.ComponentModel.DataAnnotations.Schema;

namespace Industriall.API.Models;

public class EventUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EventId { get; set; }
}