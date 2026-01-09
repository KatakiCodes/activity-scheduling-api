using MediatR;

namespace activity_scheduling.application.Commands.ExtendActivityInMinutes
{
    public record ExtendActivityInMinutesCommand : IRequest<GenericCommandResult>
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