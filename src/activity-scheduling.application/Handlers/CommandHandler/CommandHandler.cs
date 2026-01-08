using System.Threading.Tasks;
using activity_scheduling.application.Commands;
using activity_scheduling.application.Commands.Validators;
using activity_scheduling.application.Handlers.CommandHandler.Contracts;
using activity_scheduling.domain.Entities;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;

namespace activity_scheduling.application.Handlers.CommandHandler
{
    public class CommandHandler :
    ICommandHandler<CreateActivityCommand, GenericCommandResult>,
    ICommandHandler<CompleteActivityCommand, GenericCommandResult>,
    ICommandHandler<ExtendActivityInDaysCommand, GenericCommandResult>,
    ICommandHandler<ExtendActivityInHoursCommand, GenericCommandResult>,
    ICommandHandler<ExtendActivityInMinutesCommand, GenericCommandResult>,
    ICommandHandler<AntecipateActivityInDaysCommand, GenericCommandResult>,
    ICommandHandler<AntecipateActivityInHoursCommand, GenericCommandResult>,
    ICommandHandler<AntecipateActivityInMinutesCommand, GenericCommandResult>,
    ICommandHandler<CancelActivityCommand, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository;
        private readonly CreateActivityCommandValidator _Validator;
  
        public CommandHandler(IActivityRepository activityRepository)
        {
            _ActivityRepository = activityRepository;
            _Validator = new CreateActivityCommandValidator();
        }

        public async Task<GenericCommandResult> Handle(CreateActivityCommand command)
        {
            var validationResult = _Validator.Validate(command);

            if (validationResult.IsValid == false)
                return new GenericCommandResult(false, validationResult.Errors.Select(e => e.ErrorMessage).ToList().First(), null);

            var activity = new Activity(command.Name, command.StartTime, command.EndTime, command.Description);

            var creationResult = await _ActivityRepository.CreateActivityAsync(activity);

            return new GenericCommandResult(true, "Atividade criada com sucesso", creationResult);
        }

        public async Task<GenericCommandResult> Handle(CompleteActivityCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);
            if(activity == null)
                return new GenericCommandResult(false, "Atividade não encontrada", null);
            activity.CompleteActivity();
            await _ActivityRepository.UpdateActivityAsync(activity);
            return new GenericCommandResult(true, "Atividade concluida com sucesso", activity);
        }

        public async Task<GenericCommandResult> Handle(ExtendActivityInDaysCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);

                if(activity == null)
                    return new GenericCommandResult(false, "Atividade não encontrada", null);

                activity.ExtendActivityInDays(command.DaysToExtend);

                var conflictingActivity = await CheckTimeConflict(activity);
                if(conflictingActivity is not null)
                    return new GenericCommandResult(false, $"Conflito de horário com ${conflictingActivity.Count()} atividades", null);

                await _ActivityRepository.UpdateActivityAsync(activity);
                return new GenericCommandResult(true, "Periodo de atividade extendida com sucesso", activity);
        }

        public async Task<GenericCommandResult> Handle(ExtendActivityInHoursCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);

                if(activity == null)
                    return new GenericCommandResult(false, "Atividade não encontrada", null);

                activity.ExtendActivityInHours(command.HoursToExtend);

                var conflictingActivity = await CheckTimeConflict(activity);
                if(conflictingActivity is not null)
                    return new GenericCommandResult(false, $"Conflito de horário com ${conflictingActivity.Count()} atividades", null);

                await _ActivityRepository.UpdateActivityAsync(activity);
                return new GenericCommandResult(true, "Periodo de atividade extendida com sucesso", activity);
        }

        public async Task<GenericCommandResult> Handle(ExtendActivityInMinutesCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);

                if(activity == null)
                    return new GenericCommandResult(false, "Atividade não encontrada", null);

                activity.ExtendActivityInMinutes(command.MinutesToExtend);

                var conflictingActivity = await CheckTimeConflict(activity);
                if(conflictingActivity is not null)
                    return new GenericCommandResult(false, $"Conflito de horário com ${conflictingActivity.Count()} atividades", null);

                await _ActivityRepository.UpdateActivityAsync(activity);
                return new GenericCommandResult(true, "Periodo de atividade extendida com sucesso", activity);
        }

        public async Task<GenericCommandResult> Handle(AntecipateActivityInDaysCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);

                if(activity == null)
                    return new GenericCommandResult(false, "Atividade não encontrada", null);

                activity.AnticipateActivityInDays(command.DaysToAntecipate);

                var conflictingActivity = await CheckTimeConflict(activity);
                if(conflictingActivity is not null)
                    return new GenericCommandResult(false, $"Conflito de horário com ${conflictingActivity.Count()} atividades", null);

                await _ActivityRepository.UpdateActivityAsync(activity);
                return new GenericCommandResult(true, "Periodo de atividade antecipada com sucesso", activity);
        }

        public async Task<GenericCommandResult> Handle(AntecipateActivityInHoursCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);

                if(activity == null)
                    return new GenericCommandResult(false, "Atividade não encontrada", null);

                activity.AnticipateActivityInHours(command.HoursToAntecipate);

                var conflictingActivity = await CheckTimeConflict(activity);
                if(conflictingActivity is not null)
                    return new GenericCommandResult(false, $"Conflito de horário com ${conflictingActivity.Count()} atividades", null);

                await _ActivityRepository.UpdateActivityAsync(activity);
                return new GenericCommandResult(true, "Periodo de atividade antecipada com sucesso", activity);
        }
        public async Task<GenericCommandResult> Handle(AntecipateActivityInMinutesCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);

                if(activity == null)
                    return new GenericCommandResult(false, "Atividade não encontrada", null);

                activity.AnticipateActivityInMinutes(command.MinutesToAntecipate);

                var conflictingActivity = await CheckTimeConflict(activity);
                if(conflictingActivity is not null)
                    return new GenericCommandResult(false, $"Conflito de horário com ${conflictingActivity.Count()} atividades", null);

                await _ActivityRepository.UpdateActivityAsync(activity);
                return new GenericCommandResult(true, "Periodo de atividade antecipada com sucesso", activity);
        }


        public async Task<GenericCommandResult> Handle(CancelActivityCommand command)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(command.Id);
            if(activity == null)
                return new GenericCommandResult(false, "Atividade não encontrada", null);
            activity.CancelActivity();
            await _ActivityRepository.UpdateActivityAsync(activity);
            return new GenericCommandResult(true, "Atividade cancelada com sucesso", activity);
        }

        private async Task<IEnumerable<Activity>> CheckTimeConflict(Activity activityToCheck)
        {
            var conflictingActivities = new List<Activity>();

            foreach (var activity in await _ActivityRepository.GetActivitiesByStateAsync(EActivityState.SCHEDULED))
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