using System.Linq.Expressions;
using activity_scheduling.domain.Entities;
using activity_scheduling.domain.Enums;

namespace activity_scheduling.application.Queries
{
    public static class ActivityQueries
    {
        public static Expression<Func<IEnumerable<Activity>, bool>> GetAllActivities()=>
        x => x.Any();

        public static Expression<Func<IEnumerable<Activity>, bool>> GetActivitiesByState(EActivityState state)=> 
        x => x.Any(a => a.State == state);

        public static Expression<Func<Activity, bool>> GetActivityById(Guid id)=>
        x => x.Id == id;
    }
}