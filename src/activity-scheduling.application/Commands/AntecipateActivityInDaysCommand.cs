namespace activity_scheduling.application.Commands
{
    public record AntecipateActivityInDaysCommand
    {
        public AntecipateActivityInDaysCommand(Guid id, int daysToAntecipate)
        {
            Id = id;
            DaysToAntecipate = daysToAntecipate;
        }

        public Guid Id { get; init; }
        public int DaysToAntecipate { get; init; }    
    }
}