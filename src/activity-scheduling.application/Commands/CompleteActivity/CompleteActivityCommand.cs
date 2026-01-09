using MediatR;

namespace activity_scheduling.application.Commands.CompleteActivity
{
    public record CompleteActivityCommand : IRequest<GenericCommandResult>
    {
        public CompleteActivityCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}