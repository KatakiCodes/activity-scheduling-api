using activity_scheduling.application.Commands;
using activity_scheduling.application.Enums;
using activity_scheduling.application.Queries.Shared;
using activity_scheduling.domain.Repositories.Contracts;
using MediatR;

namespace activity_scheduling.application.Queries.GetAllActivities
{
    public class GetAllActivitiesHanlder(IActivityRepository activityRepository) : IRequestHandler<GetAllActivities, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;
        private readonly SharedFunctions _SharedFunctions = new(activityRepository);

        public async Task<GenericCommandResult> Handle(GetAllActivities request, CancellationToken cancellationToken)
        {
            var activities = await _ActivityRepository.GetAllActivitiesAsync();
            foreach (var activity in activities)
                await _SharedFunctions.SetAsPendingWhenStarts(activity);
            return new GenericCommandResult(true, "Atividades encontradas", activities, EStatusCodes.OK);
        }
    }
}