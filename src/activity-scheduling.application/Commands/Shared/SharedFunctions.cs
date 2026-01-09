using activity_scheduling.domain.Entities;

namespace activity_scheduling.application.Commands.Shared
{
    public static class SharedFunctions
    {
        public static async Task<IEnumerable<Activity>> CheckTimeConflict(IEnumerable<Activity> activities,Activity activityToCheck)
        {
            var conflictingActivities = new List<Activity>();

            foreach (var activity in activities)
            {
                if (activity.Id != activityToCheck.Id) // Exclude the activity being checked
                {
                    if (activity.StartTime < activityToCheck.EndTime && activityToCheck.StartTime < activity.EndTime)
                    {
                        conflictingActivities.Add(activity); // Conflict found
                    }
                }
            }
            return conflictingActivities; // Return conflicting activities
        }
    }
}