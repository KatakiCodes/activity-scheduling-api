using activity_scheduling.application.Commands.Contracts;

namespace activity_scheduling.application.Commands
{
    public record AntecipateActivityInMinutesCommand : ICommand
    {
        public AntecipateActivityInMinutesCommand(Guid id, int minutesToAntecipate)
        {
            Id = id;
            MinutesToAntecipate = minutesToAntecipate;
        }
        public Guid Id { get; init; }
        public int MinutesToAntecipate { get; init; }
    }
}