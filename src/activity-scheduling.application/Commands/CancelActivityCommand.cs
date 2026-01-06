namespace activity_scheduling.application.Commands
{
    public record CancelActivityCommand
    {
        public CancelActivityCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}