using activity_scheduling.application.Commands;
using MediatR;

namespace activity_scheduling.application.Queries.GetActivityById
{
    public record GetActivityById : IRequest<GenericCommandResult>
    {
        public GetActivityById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}