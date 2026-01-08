namespace activity_scheduling.application.Handlers.CommandHandler.Contracts
{
    public interface ICommandHandler<in ICommand, ICommandResult>
    {
        public Task<ICommandResult> Handle(ICommand command);
    }
}