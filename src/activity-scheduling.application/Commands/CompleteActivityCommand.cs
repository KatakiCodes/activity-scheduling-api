using activity_scheduling.application.Commands.Contracts;

namespace activity_scheduling.application.Commands
{
    public record CompleteActivityCommand : ICommand
    {
        public CompleteActivityCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}