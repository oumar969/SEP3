namespace Domain.DTOs;

public class SearchUserParametersDto : ISearchParametersDto
{
    public SearchUserParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }

    public string? UsernameContains { get; }
    
    public string? FirstNameContains { get; }
    public string? LastNameContains { get; }
}