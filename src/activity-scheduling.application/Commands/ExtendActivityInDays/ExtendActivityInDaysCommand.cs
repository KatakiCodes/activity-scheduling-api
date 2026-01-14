using MediatR;

namespace activity_scheduling.application.Commands.ExtendActivityInDays
{
    public record ExtendActivityInDaysCommand : IRequest<GenericCommandResult>
    {
        public ExtendActivityInDaysCommand(Guid id, int daysToExtend)
        {
            Id = id;
            DaysToExtend = daysToExtend;
        }

        public Guid Id { get; init; }
        public int DaysToExtend { get; init; }
    }
}