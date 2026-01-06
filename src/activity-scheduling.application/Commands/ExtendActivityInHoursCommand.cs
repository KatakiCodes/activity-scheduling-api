namespace activity_scheduling.application.Commands
{
    public record ExtendActivityInHoursCommand
    {
        public ExtendActivityInHoursCommand(Guid id, int hoursToExtend)
        {
            Id = id;
            HoursToExtend = hoursToExtend;
        }

        public Guid Id { get; init; }
        public int HoursToExtend { get; init; }
    }
}