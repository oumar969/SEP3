using Domain.Models;

namespace Domain.DTOs;

public class UserInformationDto
{
    public string Uuid { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Fee { get; set; }
    public BookRegistry? BookRegistry { get; set; }

}