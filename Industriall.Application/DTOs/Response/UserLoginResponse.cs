using System.Text.Json.Serialization;

namespace Industriall.Application.DTOs.Response;

public class UserLoginResponse
{
    public UserLoginResponse()
    {
        Errors = new List<string>();
    }

    public UserLoginResponse(bool Sucess, string accessToken, string refreshToken) : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public UserLoginResponse(bool Sucess) : this()
    {
    }

    public bool Sucess => Errors.Count == 0;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AccessToken { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; private set; }

    public List<string> Errors { get; }

    public void Adderror(string error)
    {
        Errors.Add(error);
    }

    public void AddErrors(IEnumerable<string> errors)
    {
        Errors.AddRange(errors);
    }
}