using activity_scheduling.application.Commands.Contracts;

namespace activity_scheduling.application.Commands
{
    public record GenericCommandResult : ICommandResult
    {
    public GenericCommandResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; init; }
    public string Message { get; init; }
    public object? Data { get; init; }
    }
}