namespace Domain.DTOs;

public class UserLoginDto
{
    public UserLoginDto(string username, string password, string token, bool success = true)
    {
        Username = username;
        Password = password;
        Token = token;
        Success = success;
    }

    public string Username { get; init; }
    public string Password { get; init; }
    public string Token { get; init; }
    public bool Success { get; init; }
}