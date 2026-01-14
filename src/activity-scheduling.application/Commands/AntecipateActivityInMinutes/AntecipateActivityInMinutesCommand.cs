using MediatR;

namespace activity_scheduling.application.Commands.AntecipateActivityInMinutes
{
    public record AntecipateActivityInMinutesCommand : IRequest<GenericCommandResult>
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