using System.Net;
using FluentResults;

namespace AmiCog.Application.Common.Errors;

public class InvalidPasswordError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}