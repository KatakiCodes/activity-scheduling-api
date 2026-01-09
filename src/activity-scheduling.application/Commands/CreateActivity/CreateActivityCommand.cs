using MediatR;

namespace activity_scheduling.application.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<GenericCommandResult>
    {
        public CreateActivityCommand(string? name, DateTime startTime, DateTime endTime, string? description)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
        }
        public string? Name { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public string? Description { get; init; } 
    }
}