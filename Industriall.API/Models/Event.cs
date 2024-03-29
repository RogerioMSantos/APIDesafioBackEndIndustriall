using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Industriall.API.Models;

public class Event
{
    private DateTime _date;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MinLength(50, ErrorMessage = "O campo {0} não pode ter menos que {1} caracteres ")]
    public string? Title { get; set; }

    [MaxLength(1000, ErrorMessage = "O campo {0} não pode exceder {1} caracteres ")]
    public string? Description { get; set; }

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

    // [Required(ErrorMessage = "O responsavel é obrigatório")]
    public int? ResponsibleId { get; set; }

    [MinLength(1, ErrorMessage = "Requer pelo menos um participante")]
    public List<User> Participants { get; set; } = null!;

    private void UpdateEventBase(Event uEvent)
    {
        Date = uEvent.Date ?? Date;
        Title = uEvent.Title ?? Title;
        Description = uEvent.Description ?? Description;
        ResponsibleId = uEvent.ResponsibleId ?? ResponsibleId;
    }

    public void UpdateEvent(Event uEvent)
    {
        UpdateEventBase(uEvent);
        Participants = uEvent.Participants;
    }

    public void UpdateMaintainEvent(Event uEvent)
    {
        UpdateEventBase(uEvent);
        Participants = uEvent.Participants;
    }
}