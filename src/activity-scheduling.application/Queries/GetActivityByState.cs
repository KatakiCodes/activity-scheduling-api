using activity_scheduling.application.Queries.Contracts;

namespace activity_scheduling.application.Queries
{
    public class GetActivityByState : IQuery
    {
        public GetActivityByState(int estateValue)
        {
            EstateValue = estateValue;
        }

        public int EstateValue { get; init; }
    }
}