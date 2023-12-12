using Newtonsoft.Json;

namespace Domain.DTOs;

public class UserDeleteDto
{
    public UserDeleteDto(string uuid, bool isSuccessful = false, string errMsg = "")
    {
        UUID = uuid;
        IsSuccessful = isSuccessful;
        ErrMsg = errMsg;
    }

    public UserDeleteDto()
    {
    }

    public string UUID { get; set; }
    public bool IsSuccessful { get; set; }
    public string ErrMsg { get; set; }
}