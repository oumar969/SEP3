namespace Domain.DTOs;

public class BookCreationDto
{
    public BookCreationDto()
    {
    }

    public BookCreationDto(string uuid, string isbn, string loanerUuid, bool isSuccesful = false, string message = "")
    {
        Uuid = uuid;
        Isbn = isbn;
        LoanerUuid = loanerUuid;
        IsSuccesful = isSuccesful;
        Message = message;
    }


    public string Uuid { get; set; }
    public string Isbn { get; set; }
    public string LoanerUuid { get; set; }
    public bool IsSuccesful { get; set; }
    public string Message { get; set; }
}