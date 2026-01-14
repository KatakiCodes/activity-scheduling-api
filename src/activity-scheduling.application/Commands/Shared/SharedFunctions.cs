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
                    // Adjust start and end times to account for the time difference
                    ResetSecondAndMiliSeconds(activity.StartTime);
                    ResetSecondAndMiliSeconds(activity.EndTime);

                    ResetSecondAndMiliSeconds(activityToCheck.StartTime);
                    ResetSecondAndMiliSeconds(activityToCheck.EndTime);

                    //Cheack 

                    if (!(activity.StartTime < activityToCheck.StartTime) && !(activity.StartTime > activityToCheck.EndTime))
                        conflictingActivities.Add(activity); // Conflict found
                }
            }
            return conflictingActivities; // Return conflicting activities
        }
        private static void ResetSecondAndMiliSeconds(DateTime date)
        {
            date.AddSeconds(- date.Second);
            date.AddMilliseconds(- date.Millisecond);
        }
    }
}