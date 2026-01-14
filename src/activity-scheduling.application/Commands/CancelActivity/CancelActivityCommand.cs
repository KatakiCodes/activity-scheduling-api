using MediatR;

namespace activity_scheduling.application.Commands.CancelActivity
{
    public record CancelActivityCommand : IRequest<GenericCommandResult>
    {
        public CancelActivityCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}