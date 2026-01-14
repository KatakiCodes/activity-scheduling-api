using MediatR;

namespace activity_scheduling.application.Commands.AntecipateActivityInDays
{
    public record AntecipateActivityInDaysCommand : IRequest<GenericCommandResult>
    {
        public AntecipateActivityInDaysCommand(Guid id, int daysToAntecipate)
        {
            Id = id;
            DaysToAntecipate = daysToAntecipate;
        }

        public Guid Id { get; init; }
        public int DaysToAntecipate { get; init; }    
    }
}