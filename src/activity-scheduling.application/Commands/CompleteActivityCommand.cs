    namespace activity_scheduling.application.Commands
{
    public record CompleteActivityCommand
    {
        public CompleteActivityCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}