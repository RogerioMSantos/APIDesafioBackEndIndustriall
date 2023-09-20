using System.Text.Json.Serialization;

namespace Industriall.Application.DTOs.Response;

public class UserLoginResponse
{
    private UserLoginResponse()
    {
        Errors = new List<string>();
    }

    public UserLoginResponse(bool success, string accessToken, string refreshToken) : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public UserLoginResponse(bool success) : this()
    {
    }

    public bool Success => Errors.Count == 0;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AccessToken { get; private set; } = null!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; private set; } = null!;

    public List<string> Errors { get; }

    public void AddError(string error)
    {
        Errors.Add(error);
    }

    public void AddErrors(IEnumerable<string> errors)
    {
        Errors.AddRange(errors);
    }
}