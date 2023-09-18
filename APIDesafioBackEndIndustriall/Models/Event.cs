using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace APIDesafioBackEndIndustriall.Models;

public class Event
{
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    
    private DateTime _date;

    [MinLength(50, ErrorMessage = "O campo {0} não pode ter menos que {1} caracteres ")]
    public string? Title { get; set; } = null!;

    [MaxLength(1000, ErrorMessage = "O campo {0} não pode exceder {1} caracteres ")]
    public string? Description { get; set; } = null!;

    [DefaultValue("01/01/2023")]
    public string? Date
    {
        get => _date.ToString("dd/MM/yyyy");
        set
        {
            if (DateTime.TryParseExact(value, "dd/MM/yyyy", null, DateTimeStyles.None, out var parsedDate))
                _date = parsedDate;
            else
                throw new ArgumentException("Formato de data inválido. Use o formato 'dd/MM/yyyy'.");
        }
    }

    [Required(ErrorMessage = "O responsavel é obrigatório")]
    public User? Responsable { get; set; } = null!;

    [MinLength(1, ErrorMessage = "Requer pelo menos um participante")]
    public List<User> Participants { get; set; } = null!;

    public void UpdateEvent(Event uEvent)
    {
        Date = uEvent.Date ?? Date;
        Title = uEvent.Title ?? Title;
        Description = uEvent.Description ?? Description;
        Responsable = uEvent.Responsable ?? Responsable;
        Participants = uEvent.Participants ?? Participants;
    }
}