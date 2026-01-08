using activity_scheduling.application.Commands.Contracts;
using activity_scheduling.application.Queries.Contracts;

namespace activity_scheduling.application.Handlers.QueryHandler.Contracts
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery where TResult : ICommandResult
    {
        public Task<TResult> Handle(TQuery query);
    }
}