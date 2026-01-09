using MediatR;

namespace activity_scheduling.application.Commands.ExtendActivityInHours
{
    public record ExtendActivityInHoursCommand : IRequest<GenericCommandResult>
    {
        public ExtendActivityInHoursCommand(Guid id, int hoursToExtend)
        {
            Id = id;
            HoursToExtend = hoursToExtend;
        }

        public Guid Id { get; init; }
        public int HoursToExtend { get; init; }
    }
}