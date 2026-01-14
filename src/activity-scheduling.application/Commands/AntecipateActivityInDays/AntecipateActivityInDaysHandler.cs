using activity_scheduling.application.Commands.Shared;
using activity_scheduling.application.Enums;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;
using MediatR;

namespace activity_scheduling.application.Commands.AntecipateActivityInDays
{
    public class AntecipateActivityInDaysHandler(IActivityRepository activityRepository) : IRequestHandler<AntecipateActivityInDaysCommand, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;

        public async Task<GenericCommandResult> Handle(AntecipateActivityInDaysCommand request, CancellationToken cancellationToken)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(request.Id);

            if (activity == null)
                return new GenericCommandResult(false, "Atividade não encontrada", null, EStatusCodes.NOTFOUND);

            activity.AnticipateActivityInDays(request.DaysToAntecipate);

            var getAllActivities = await _ActivityRepository.GetAllActivitiesAsync();

            var filterActivityByState = getAllActivities.Where(a => a.State == EActivityState.SCHEDULED && a.State == EActivityState.PENDING);

            var conflictingActivity = await SharedFunctions.CheckTimeConflict(filterActivityByState, activity);

            if (conflictingActivity.Any())
                return new GenericCommandResult(false, $"Conflito de horário com ${conflictingActivity.Count()} atividades", null, EStatusCodes.BADREQUEST);

            await _ActivityRepository.UpdateActivityAsync(activity);
            return new GenericCommandResult(true, "Periodo de atividade antecipada com sucesso", activity, EStatusCodes.OK);
        }
    }
}