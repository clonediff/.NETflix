namespace DtoLibrary.AuthDto;

public class GoogleCallback
{
    public string Code { get; set; }
    
    //public string Error { get; set; }
    
    public string Scope { get; set; }
}

/*public class GoogleErrorCallback
{
    public string Error { get; set; }
}

public class GoogleResult
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

}*/