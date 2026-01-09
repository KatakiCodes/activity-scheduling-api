using MediatR;

namespace activity_scheduling.application.Commands.AntecipateActivityInHours
{
    public record AntecipateActivityInHoursCommand : IRequest<GenericCommandResult>
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