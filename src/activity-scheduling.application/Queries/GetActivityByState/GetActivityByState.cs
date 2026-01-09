using activity_scheduling.application.Commands;
using activity_scheduling.domain.Entities;
using MediatR;

namespace activity_scheduling.application.Queries.GetActivityByState
{
    public class GetActivityByState : IRequest<GenericCommandResult>
    {
        public GetActivityByState(int estateValue)
        {
            EstateValue = estateValue;
        }

        public int EstateValue { get; init; }
    }
}