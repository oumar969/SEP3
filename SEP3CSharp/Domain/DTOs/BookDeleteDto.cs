namespace Domain.DTOs;

public class BookDeleteDto
{
    public BookDeleteDto()
    {
    }

    public BookDeleteDto(string uuid, string isbn, string loanerUuid, bool isSuccessful = false, string message = "")
    {
        Uuid = uuid;
        Isbn = isbn;
        LoanerUuid = loanerUuid;
        IsSuccessful = isSuccessful;
        Message = message;
    }


    public string Uuid { get; set; }
    public string Isbn { get; set; }
    public string LoanerUuid { get; set; }
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
}