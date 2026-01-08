using activity_scheduling.application.Commands.Contracts;

namespace activity_scheduling.application.Commands
{
    public class CreateActivityCommand : ICommand
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