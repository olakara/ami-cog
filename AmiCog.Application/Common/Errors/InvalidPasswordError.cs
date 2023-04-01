using System.Net;

namespace AmiCog.Application.Common.Errors;

public class InvalidPasswordError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErrorMessage => "Invalid Password!";
}