namespace Domain.DTOs;

public class UserLoginDto
{
    public UserLoginDto(string email, string password, string token = null, bool success = true, string errMsg = null)
    {
        Email = email;
        Password = password;
        Token = token;
        Success = success;
        ErrMsg = errMsg;
    }

    public string Email { get; init; }
    public string Password { get; init; }
    public string Token { get; init; }
    public bool Success { get; init; }
    public string ErrMsg { get; init; }

    public override string ToString()
    {
        return
            $"{nameof(Email)}: {Email}, {nameof(Password)}: {Password}, {nameof(Token)}: {Token}, {nameof(Success)}: {Success}, {nameof(ErrMsg)}: {ErrMsg}";
    }
}
