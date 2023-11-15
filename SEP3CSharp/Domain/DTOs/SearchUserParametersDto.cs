namespace Domain.DTOs;

public class SearchUserParametersDto
{
    public SearchUserParametersDto(string? email)
    {
        Email = email;
    }

    public string? Email { get; set; }
}