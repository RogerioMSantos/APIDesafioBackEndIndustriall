using System.Text.Json.Serialization;

namespace Industriall.Application.DTOs.Response;

public class UserLoginResponse
{
    public bool Sucess  => Errors.Count == 0;
        
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AccessToken { get; private set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; private set; }
        
    public List<string> Errors { get; private set; }

    public UserLoginResponse() =>
        Errors = new List<string>();

    public UserLoginResponse(bool Sucess, string accessToken, string refreshToken) : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public void AdicionarErro(string erro) =>
        Errors.Add(erro);

    public void AdicionarErrors(IEnumerable<string> erros) =>
        Errors.AddRange(erros);
}