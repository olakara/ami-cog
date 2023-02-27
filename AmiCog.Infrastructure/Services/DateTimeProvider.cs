using AmiCog.Application.Common.Interfaces.Services;

namespace AmiCog.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}