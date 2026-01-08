using activity_scheduling.domain.Entities;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;
using activity_scheduling.infra.data.DataContexts;

namespace activity_scheduling.infra.data.Repositories
{
    public class ActivityRepository(ApplicationDbContext dbContext) : IActivityRepository
    {
        private readonly ApplicationDbContext _DbContext = dbContext;
        public Task<Activity> CreateActivityAsync(Activity activity)
        {
            _DbContext.AddAsync(activity);
            _DbContext.SaveChangesAsync();
            return Task.FromResult(activity);
        }

        public Task<IEnumerable<Activity>> GetActivitiesByStateAsync(EActivityState state)
        {
            var activities = _DbContext.Activities.Where(a=>a.State == state).ToList();
            return Task.FromResult(activities.AsEnumerable());
        }

        public Task<Activity> GetActivityByIdAsync(Guid id)
        {
            var activity = _DbContext.Activities.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(activity);
        }

        public Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            var activities = _DbContext.Activities.ToList();
            return Task.FromResult(activities.AsEnumerable());
        }

        public Task<Activity> UpdateActivityAsync(Activity activity)
        {
            _DbContext.Update(activity);
            _DbContext.SaveChangesAsync();
            return Task.FromResult(activity);
        }
    }
}