using activity_scheduling.application.Commands.Contracts;

namespace activity_scheduling.application.Commands
{
    public record ExtendActivityInMinutesCommand : ICommand
    {
        public ExtendActivityInMinutesCommand(Guid id, int minutesToExtend)
        {
            Id = id;
            MinutesToExtend = minutesToExtend;
        }

        public Guid Id { get; init; }
        public int MinutesToExtend { get; init; }
    }
}