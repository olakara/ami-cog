using System.Net;
using FluentResults;

namespace AmiCog.Application.Common.Errors;

public class UserNotExistsError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}