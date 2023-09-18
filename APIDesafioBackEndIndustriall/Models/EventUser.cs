using System.ComponentModel.DataAnnotations.Schema;

namespace APIDesafioBackEndIndustriall.Models;

public class EventUser
{
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int EventId { get; set; }
    
}