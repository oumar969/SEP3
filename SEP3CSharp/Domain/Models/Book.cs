using Newtonsoft.Json;

namespace Domain.Models;

public class Book
{
    public Book(string isbn, string uuid, string loanerUuid)
    {
        Isbn = isbn;
        UUID = uuid;
        LoanerUuid = loanerUuid;
    }

    [JsonProperty("uuid")] public string UUID { get; set; }
    
    [JsonProperty("isbn")]public string Isbn { get; set; }
    [JsonProperty("loanerUuid")] public string LoanerUuid { get; set; }
}
