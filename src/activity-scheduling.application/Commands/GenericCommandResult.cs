using activity_scheduling.application.Enums;

namespace activity_scheduling.application.Commands
{
    public record GenericCommandResult
    {
    public GenericCommandResult(bool success, string message, object data, EStatusCodes statusCode)
    {
        Success = success;
        Message = message;
        Data = data;
        StatusCode = statusCode;
    }

    public bool Success { get; init; }
    public string Message { get; init; }
    public object? Data { get; init; }
    public EStatusCodes StatusCode { get; init; }
    }
}