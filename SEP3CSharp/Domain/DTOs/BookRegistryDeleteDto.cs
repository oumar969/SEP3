namespace Domain.DTOs;

public class BookRegistryDeleteDto
{
    public BookRegistryDeleteDto()
    {
    }

    public BookRegistryDeleteDto(string isbn,
        bool isSuccessful = false, string message = "")
    {
        Isbn = isbn;
        IsSuccessful = isSuccessful;
        Message = message;
    }


    public string Isbn { get; init; }
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
}