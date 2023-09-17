using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace APIDesafioBackEndIndustriall.Models;

public class Event
{
    [MinLength(50,ErrorMessage = "O {0} não pode ter menos que {1} caracteres ")]
    public string Title { get; set; }
    
    [MaxLength(1000,ErrorMessage = "A {0} não pode exceder {1} caracteres ")]
    public string Description { get; set; }

    private DateTime _date;
    
    [DefaultValue("01/01/2023")] 
    public string  Date {
        get
        {
            return _date.ToString("dd/MM/yyyy");
        }
        set
        {
            if ( DateTime.TryParseExact(value, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime parsedDate))
            {
                _date = parsedDate;
            }
            else
            {
                throw new ArgumentException("Formato de data inválido. Use o formato 'dd/MM/yyyy'.");
            }
        }
    } 
    
    [Required(ErrorMessage = "O responsavel é obrigatório")]
    public User Responsable { get; set; }
    
    [MinLength(1,ErrorMessage = "Requer pelo menos um participante")]
    public User[] Participants { get; set; }
    
}