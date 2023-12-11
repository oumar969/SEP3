namespace Domain.DTOs;

public class UserLoginDto
{
    public UserLoginDto(string email, string password, string token = null, bool success = true, string message = "")
    {
        Email = email;
        Password = password;
        Token = token;
        IsSuccess = success;
        Message = message;
    }

    public string Email { get; init; }
    public string Password { get; init; }
    public string Token { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(Email)}: {Email}, {nameof(Password)}: {Password}, {nameof(Token)}: {Token}, {nameof(IsSuccess)}: {IsSuccess}, {nameof(Message)}: {Message}";
    }
}