using activity_scheduling.application.Commands;
using activity_scheduling.application.Enums;
using activity_scheduling.application.Queries.Shared;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;
using MediatR;

namespace activity_scheduling.application.Queries.GetActivityByState
{
    public class GetActivityByStateHandler(IActivityRepository activityRepository) : IRequestHandler<GetActivityByState, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;
        private readonly SharedFunctions _SharedFunctions = new(activityRepository);

        public async Task<GenericCommandResult> Handle(GetActivityByState request, CancellationToken cancellationToken)
        {
            var activities = await _ActivityRepository.GetActivitiesByStateAsync((EActivityState) request.EstateValue);

            foreach(var activity in activities)
                await _SharedFunctions.SetAsPendingWhenStarts(activity);

            return new GenericCommandResult(true, "Atividade encontrada", activities, EStatusCodes.OK);
        }
    }
}