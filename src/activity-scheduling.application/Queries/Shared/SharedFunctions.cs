
using activity_scheduling.domain.Entities;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;

namespace activity_scheduling.application.Queries.Shared
{
    public class SharedFunctions(IActivityRepository activityRepository)
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;

        public async Task SetAsPendingWhenStarts(Activity activity)
        {
            if ((activity.StartTime < DateTime.Now) && (activity.State == EActivityState.SCHEDULED))
            {
                activity.SetAsPending();
                await _ActivityRepository.UpdateActivityAsync(activity);

            }
        }
    }
}