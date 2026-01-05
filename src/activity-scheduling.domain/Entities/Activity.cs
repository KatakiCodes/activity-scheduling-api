using activity_scheduling.domain.Enums;

namespace activity_scheduling.domain.Entities
{
    public class Activity : Entity
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public EActivityState State { get; set; }

        public Activity(Guid id, string name, DateTime startTime, DateTime endTime, string description, EActivityState state)
            : base(id)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
            State = state;
        }

        public Activity(string name, DateTime startTime, DateTime endTime, string description)
        {
            Name = name;
            StartTime = startTime;
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
    }
}