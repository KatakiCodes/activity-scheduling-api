using activity_scheduling.application.Queries.Contracts;

namespace activity_scheduling.application.Queries
{
    public record GetActivityById : IQuery
    {
        public GetActivityById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}