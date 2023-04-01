using System.Net;

namespace AmiCog.Application.Common.Errors;

public class UserNotExistsError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "User not registered!";
}