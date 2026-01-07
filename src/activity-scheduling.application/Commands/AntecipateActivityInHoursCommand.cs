using activity_scheduling.application.Commands.Contracts;

namespace activity_scheduling.application.Commands
{
    public record AntecipateActivityInHoursCommand : ICommand
    {
        public AntecipateActivityInHoursCommand(Guid id, int hoursToAntecipate)
        {
            Id = id;
            HoursToAntecipate = hoursToAntecipate;
        }

        public Guid Id { get; init; }
        public int HoursToAntecipate { get; init; }
    }
}