using activity_scheduling.domain.Enums;

namespace activity_scheduling.domain.Entities
{
    public class Activity : Entity
    {
        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime ScheduleTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Description { get; private set; }
        public EActivityState State { get; private set; }

        public Activity(Guid id, string name, DateTime startTime, DateTime scheduleTime, DateTime endTime, string description, EActivityState state)
            : base(id)
        {
            Name = name;
            StartTime = startTime;
            ScheduleTime = scheduleTime;
            EndTime = endTime;
            Description = description;
            State = state;
        }

        public Activity(string name, DateTime startTime, DateTime endTime, string description)
        {

            Name = name;
            StartTime = startTime;
            ScheduleTime = DateTime.UtcNow;
            EndTime = endTime;
            Description = description;
            State = EActivityState.SCHEDULED;
        }
        public void CompleteActivity()
        {
            State = EActivityState.COMPLETED;
        }
        public void CancelActivity()
        {
            State = EActivityState.CANCELLED;
        }
        public void ExtendActivityInMinutes(int minutesToExtend)
        {
            EndTime = EndTime.AddMinutes(minutesToExtend);
            State = EActivityState.EXTENDED;
        }
        public void ExtendActivityInHours(int hoursToExtend)
        {
            EndTime = EndTime.AddHours(hoursToExtend);
            State = EActivityState.EXTENDED;
        }
        public void ExtendActivityInDays(int daysToExtend)
        {
            EndTime = EndTime.AddDays(daysToExtend);
            State = EActivityState.EXTENDED;
        }
        public void AnticipateActivityInMinutes(int minutesToAnticipate)
        {
            EndTime = EndTime.AddMinutes(-minutesToAnticipate);
            State = EActivityState.ANTICIPATED;
        }
        public void AnticipateActivityInHours(int hoursToAnticipate)
        {
            EndTime = EndTime.AddHours(-hoursToAnticipate);
            State = EActivityState.ANTICIPATED;
        }
        public void AnticipateActivityInDays(int daysToAnticipate)
        {
            EndTime = EndTime.AddDays(-daysToAnticipate);
            State = EActivityState.ANTICIPATED;
        }
    }
}