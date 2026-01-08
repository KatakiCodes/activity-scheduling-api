using activity_scheduling.application.Commands;
using activity_scheduling.application.Handlers.QueryHandler.Contracts;
using activity_scheduling.application.Queries;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;

namespace activity_scheduling.application.Handlers.QueryHandler
{
    public class QueryHandler :
        IQueryHandler<GetActivityById, GenericCommandResult>,
        IQueryHandler<GetActivityByState, GenericCommandResult>,
        IQueryHandler<GetAllActivities, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository;
        public QueryHandler(IActivityRepository activityRepository)
        {
            _ActivityRepository = activityRepository;
        }
        public async Task<GenericCommandResult> Handle(GetActivityById query)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(query.Id);
            if (activity == null)
                return new GenericCommandResult(false, "Atividade não encontrada", null);
            return new GenericCommandResult(true, "Atividade encontrada", activity);
        }

        public async Task<GenericCommandResult> Handle(GetAllActivities query)
        {
            var activities = await _ActivityRepository.GetAllActivitiesAsync();
            return new GenericCommandResult(true, "Atividades encontradas", activities);
        }

        public async Task<GenericCommandResult> Handle(GetActivityByState query)
        {
            var activities = await _ActivityRepository.GetActivitiesByStateAsync((EActivityState)query.EstateValue);
            return new GenericCommandResult(true, "Atividades encontradas", activities);
        }
    }
}