using activity_scheduling.application.Commands;
using activity_scheduling.application.Enums;
using activity_scheduling.application.Queries.Shared;
using activity_scheduling.domain.Repositories.Contracts;
using MediatR;

namespace activity_scheduling.application.Queries.GetActivityById
{
    public class GetActivityByIdHandler(IActivityRepository activityRepository) : IRequestHandler<GetActivityById, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;
        private readonly SharedFunctions _SharedFunctions = new(activityRepository);

        public async Task<GenericCommandResult> Handle(GetActivityById request, CancellationToken cancellationToken)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(request.Id);
            await _SharedFunctions.SetAsPendingWhenStarts(activity);
            if (activity == null)
                return new GenericCommandResult(false, "Atividade não encontrada", null, EStatusCodes.NOTFOUND);
            return new GenericCommandResult(true, "Atividade encontrada", activity, EStatusCodes.OK);
        }
    }
}