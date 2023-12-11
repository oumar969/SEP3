namespace Domain.DTOs;

public class SearchUserParametersDto : ISearchParametersDto
{
    public SearchUserParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }

    public SearchUserParametersDto(string? firstNameContains, string? lastNameContains)
    {
        FirstNameContains = firstNameContains;
        LastNameContains = lastNameContains;
    }

    public SearchUserParametersDto()
    {
        
    }


    public string? UsernameContains { get; }
    
    public string? FirstNameContains { get; set; }
    public string? LastNameContains { get; init; }
}
