using activity_scheduling.application.Commands;
using activity_scheduling.domain.Entities;
using MediatR;

namespace activity_scheduling.application.Queries.GetAllActivities
{
    public class GetAllActivities : IRequest<GenericCommandResult>
    { }
}