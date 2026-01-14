using activity_scheduling.domain.Entities;
using activity_scheduling.domain.Enums;

namespace activity_scheduling.domain.Repositories.Contracts
{
    public interface IActivityRepository
    {
        public Task<IEnumerable<Activity>> GetAllActivitiesAsync();
        public Task<IEnumerable<Activity>> GetActivitiesByStateAsync(EActivityState state);
        public Task<Activity> GetActivityByIdAsync(Guid id);
        public Task<Activity> CreateActivityAsync(Activity activity);
        public Task<Activity> UpdateActivityAsync(Activity activity);
    }
}