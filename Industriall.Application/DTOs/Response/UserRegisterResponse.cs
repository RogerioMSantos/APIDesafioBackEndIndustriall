namespace Industriall.Application.DTOs.Response;

public class UserRegisterResponse
{
    public UserRegisterResponse()
    {
        Errors = new List<string>();
    }

    public UserRegisterResponse(bool sucess = true) : this()
    {
        Sucess = sucess;
    }

    public bool Sucess { get; private set; }
    public List<string> Errors { get; }

    public void AddErrors(IEnumerable<string> errors)
    {
        Errors.AddRange(errors);
    }
}