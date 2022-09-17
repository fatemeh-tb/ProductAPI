namespace ProductShop.models.UserDomain;

public class LoginResponse
{
    public Boolean? isAuthSuccessful  { get; set; }
    public string? errorMessage  { get; set; }
    
    public string? token { get; set; }

}