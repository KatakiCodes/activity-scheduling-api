namespace activity_scheduling.application.Commands
{
    public record ExtendActivityInDaysCommand
    {
        public ExtendActivityInDaysCommand(Guid id, int daysToExtend)
        {
            Id = id;
            DaysToExtend = daysToExtend;
        }

        public Guid Id { get; init; }
        public int DaysToExtend { get; init; }
    }
}